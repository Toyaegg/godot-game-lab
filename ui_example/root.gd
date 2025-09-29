extends Node

@export
var UIRoot: CanvasLayer

var test := preload("res://gui/modal/message/message.tscn")

func _ready() -> void:
	var ui := test.instantiate() as Modal
	UIRoot.add_child(ui)
	ui.setup(Modal.ModalType.message, "测试", true)
	print(str(Modal.ModalType.message))
	ui.confirm.connect(func() -> void:
		print("confirm")
	)
	ui.set_content("测试")



