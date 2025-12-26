extends Node


func _ready() -> void:
	var timer = get_tree().create_timer(1.0).timeout.connect(_on_timer_timeout)

func _on_timer_timeout() -> void:
	var resource = load("res://test/test.dialogue")
	DialogueManager.show_dialogue_balloon(resource, "测试")