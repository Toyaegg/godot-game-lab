extends Control

@onready var continue_btn: Button = $"VBoxContainer/Continue"
var has_save: bool = false


func _ready():
    continue_btn.disabled = not has_save
