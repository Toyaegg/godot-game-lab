extends Node2D

func _ready() -> void:
	var resource = load("res://test/test.dialogue")
	
	DialogueManager.show_dialogue_balloon(resource, "start")
