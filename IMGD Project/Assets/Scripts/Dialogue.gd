extends Node2D


# Called when the node enters the scene tree for the first time.
# func _ready():
	# var dialog = Dialogic.start("convo_1")
	# add_child(dialog)

func _startVeronicaDialog(taskComp):
	Dialogic.VAR.tasksCompleted = taskComp

	if (Dialogic.VAR.timesSpokenToVeronica == 0):
		var dialog = Dialogic.start("convo_1")
	elif (Dialogic.VAR.timesSpokenToVeronica >= 1):
		if (taskComp == 7):
			var dialog = Dialogic.start("convo_5")
		else:
			var dialog = Dialogic.start("convo_3")
	# add_child(dialog)

func _startZaynDialog():
	if (Dialogic.VAR.timesSpokenToVeronica == 0):
		var dialog = Dialogic.start("convo_4")
	else:
		var dialog = Dialogic.start("convo_2")
	# add_child(dialog)

func _startZoeDialog():
	if (Dialogic.VAR.timesSpokenToVeronica == 0):
		var dialog = Dialogic.start("convo_6")
	else:
		var dialog = Dialogic.start("convo_7")
