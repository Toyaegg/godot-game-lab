using Godot;
using Arch.Core;
using Arch.Core.Extensions;
using Arch.System;

public partial class ArchTest : Node
{
    private World world;
    private Group<float> group;

    public void Init()
    {
        // Create a world and an entity with position and velocity.
        world = World.Create();
        var adventurer = world.Create(new Position(0,0), new Velocity(1,1));
        var adventurer2 = world.Create(new Position(0,0));
        var adventurer3 = world.Create(new Position(0,0), new Shelflife(60));
        var adventurer4 = world.Create(new Velocity(0.5f,0.5f), new Shelflife(60));
        var adventurer6 = world.Create(new Velocity(0.5f,0.5f));
        var adventurer5 = world.Create(new Shelflife(20));
        
        RandomNumberGenerator rnd = new RandomNumberGenerator();
        
        for (int i = 0; i < 10000; i++)
        {
            world.Create(new Shelflife(rnd.RandfRange(5, 20)));
        }
        
        group = new Group<float>(
            "sd", 
            new ShelflifeSystem(world), 
            new ShelflifeDestroySystem(world), 
            new MoveSystem(world)
            );
        
        Timer timer = new Timer();
        timer.Autostart = true;
        timer.Timeout += Process;
        timer.WaitTime = 1;
        AddChild(timer);
        timer.Start();
    }

    public void Process()
    {
        group.Update(1);
        // world.TrimExcess();
    }
}

public record struct Position(float X, float Y);
public record struct Velocity(float Dx, float Dy);
public record struct Shelflife(float lifeTime);

public record struct Rot();

public class ShelflifeSystem : BaseSystem<World, float>
{
    private QueryDescription _desc = new QueryDescription().WithAll<Shelflife>();
    public ShelflifeSystem(World world) : base(world)
    {
    }
    
    public override void Update(in float deltaTime)
    {
        float delta = deltaTime;
        // Run query, can also run multiple queries inside the update
        World.Query(in _desc, (Entity entity, ref Shelflife lifeTime) =>
        {
            lifeTime.lifeTime -= delta;
            if (lifeTime.lifeTime <= 0)
            {
                entity.Add(new Rot());
            }
        });
    }
}

public class ShelflifeDestroySystem : BaseSystem<World, float>
{
    private QueryDescription _desc = new QueryDescription().WithAll<Rot>();
    private QueryDescription _descs = new QueryDescription().WithAll<Shelflife>();
    public ShelflifeDestroySystem(World world) : base(world)
    {
    }
    
    public override void Update(in float deltaTime)
    {
        // Run query, can also run multiple queries inside the update
        // World.Query(in _desc, (Entity entity) => {
        //     if (entity.Has<Shelflife>() &&  entity.Get<Shelflife>().rot)
        //     {
        //         entity.Remove<Shelflife>();
        //     }
        // }); 
        
        World.Destroy(in _desc);
        
        GD.Print(World.CountEntities(in _descs));
    }
}

public class MoveSystem : BaseSystem<World, float>
{
    private QueryDescription _desc = new QueryDescription().WithAll<Position, Velocity>();
    public MoveSystem(World world) : base(world)
    {
    }
    
    public override void Update(in float deltaTime)
    {
        // Run query, can also run multiple queries inside the update
        World.Query(in _desc, (ref Position pos, ref Velocity vel) => {
            pos.X += vel.Dx;
            pos.Y += vel.Dy;
        });
    }
}