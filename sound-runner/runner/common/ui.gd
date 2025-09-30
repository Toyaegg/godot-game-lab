extends Control
class_name UI

func _open() -> void:
	visible = true
	print("UI open")


func _hide() -> void:
	visible = true


func _destroy() -> void:
	queue_free()
