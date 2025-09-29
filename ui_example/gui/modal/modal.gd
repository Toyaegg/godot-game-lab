extends Control
class_name Modal

enum ModalType{
	message,
	prompt,
	confirm
}

@onready var mask: PanelContainer = $Mask
@onready var modal_title: Label = $Back/Control/MainContainer/Title
@onready var modal_content:= $Back/Control/MainContainer/Container/Content
@onready var button: Button = $Back/Control/MainContainer/ButtonContainer/Buttons/Button
@onready var buttons: HBoxContainer = $Back/Control/MainContainer/ButtonContainer/Buttons

var confirm_button: Button
var cancel_button: Button
var modal_type: ModalType

signal confirm(info:String)
signal cancel

func _ready() -> void:
	self.confirm_button = button.duplicate()
	self.cancel_button = button.duplicate()
	button.queue_free()

func setup(type: ModalType, title: String, use_mask: bool = false) -> void:
	self.modal_type = type
	self.mask.visible = use_mask
	self.modal_title.text = title
	
	confirm_button.text = "确认"
	buttons.add_child(confirm_button)
	if self.modal_type == ModalType.prompt or self.modal_type == ModalType.confirm:
			self.cancel_button.text = "取消"
			buttons.add_child(self.cancel_button)
	
	self.confirm_button.pressed.connect(func() -> void:
		if self.modal_type == ModalType.message:
			confirm.emit()
		else:
			confirm.emit(self.modal_content.text)
		)
	
	self.cancel_button.pressed.connect(func() -> void:
		cancel.emit()
		)
		

func set_content(content: String) -> void:
	if self.modal_type == ModalType.message:
		self.modal_content.text = content
