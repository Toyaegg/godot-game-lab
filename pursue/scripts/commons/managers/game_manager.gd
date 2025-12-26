extends Node
class_name GameManager

func _ready() -> void:
	var inital:PackedScene = load("res://scenes/gui/initalization/initalization.tscn")
	# 初始化UIManager
	# TODO 添加UIManager
	# 打开初始化界面，播放开发者logo
	add_child(inital.instantiate())
	# 初始化GlobalDataManager
	# TODO 添加GlobalDataManager
	
