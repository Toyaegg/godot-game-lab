extends Node2D

func _ready() -> void:
	var resource = load("res://test/test.dialogue")
	
	var balloon = DialogueManager.show_dialogue_balloon(resource, "测试") as CanvasLayer
	DialogueManager.dialogue_ended.connect(func(arg):
		print("结束了", arg, balloon)
		#balloon.hide()
	)
