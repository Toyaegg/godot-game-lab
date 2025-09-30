extends Node

@onready var ui_root: CanvasLayer = $UiRoot

var level_manager: LevelManager = null

func _ready() -> void:
	UIManager.set_root(ui_root)
	
	level_manager = LevelManager.new()
	
	UIManager.open(UIConstant.UI_INITIALIZE)
	get_tree().create_timer(3).timeout.connect(func():
		UIManager.open(UIConstant.UI_INITIALIZE)
	)
	get_tree().create_timer(6).timeout.connect(func():
		UIManager.open(UIConstant.UI_HUD)
	)
	get_tree().create_timer(9).timeout.connect(func():
		UIManager.open(UIConstant.UI_HUD)
	)

func _process(delta: float) -> void:
	pass
