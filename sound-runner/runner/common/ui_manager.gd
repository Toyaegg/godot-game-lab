extends Node

var ui_root: CanvasLayer = null # UI根节点
var cache: Dictionary[String, PackedScene] # 所有加载过的UI场景
var stack: Array[UI] # 已经打开过的UI实例
var persistent: Array[UI] # 常驻UI实例

func set_root(root: CanvasLayer) -> void:
	ui_root = root
	print("UIManager set root: ", ui_root.get_path())

func _ready() -> void:
	pass

func open(path: String, persistant: bool = false) -> void:
	print("UIManager open: ", path)
	
	if cache.has(path):
		print("loaded")
		var ins_idx: int = stack.find_custom(func(ui):
			return ui.scene_file_path == path
		)
		
		if ins_idx == -1:
			print("dont have instance")
			var instance: UI = cache[path].instantiate()
			ui_root.add_child(instance)
			instance._open()
		else:
			print("have instance")
			var instance = stack[ins_idx]
			stack.remove_at(ins_idx)
			stack.push_back(instance)
	else:
		print("not loaded")
		var ui: PackedScene = load(path)
		var instance: UI = ui.instantiate()
		ui_root.add_child(instance)
		instance._open()
		cache[path] = ui
		stack.push_back(instance)

func close(path: String, destroy: bool = false) -> void:
	print("UIManager hide: ", path)
	
	var ins_idx: int = stack.find_custom(func(ui):
		return ui.scene_file_path == path
	)
	
	if ins_idx == -1:
		print("dont have instance")
	else:
		print("have instance")
		var instance = stack[ins_idx]
		if destroy:
			instance._destroy()
		else:
			instance._hide()
		
	var per_idx: int = persistent.find_custom(func(ui):
		return ui.scene_file_path == path
	)
	
	if per_idx == -1:
		print("dont have instance")
	else:
		print("have instance")
		var instance = persistent[per_idx]
		if destroy:
			instance._destroy()
		else:
			instance._hide()
	
