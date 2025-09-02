extends Node

@onready var canvas_layer: CanvasLayer = $CanvasLayer

var test:PackedScene = preload("res://scenes/gui/modal/message/message.tscn")
#var test:PackedScene = preload("res://scenes/gui/modal/prompt/prompt.tscn")

func _ready() -> void:
	var t = test.instantiate() as Modal
	canvas_layer.add_child(t)
	t.setup(Modal.ModalType.message, "测试")
	t.set_content("dawww")
	t.confirm.connect(confirm)
	t.cancel.connect(cancel)


func confirm(info: String = '') -> void:
	print("pressed confirm ", info)
func cancel() -> void:
	print("pressed cancel")
