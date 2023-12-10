extends Node2D


# Called when the node enters the scene tree for the first time.
func _ready():
	var dialog = Dialogic.start("convo_1")
	add_child(dialog)

