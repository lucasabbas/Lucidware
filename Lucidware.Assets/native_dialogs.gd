extends Node

var dialog_id : int = 0

signal dialog_confirmed(id : int)
signal dialog_canceled(id : int)

func push_accept_info(msg : String, title: String = "Info") -> int:
	var accept_dialog := NativeAcceptDialog.new()
	accept_dialog.dialog_icon = NativeAcceptDialog.ICON_INFO
	accept_dialog.title = title
	accept_dialog.dialog_text = msg
	
	var id := dialog_id
	accept_dialog.confirmed.connect(func ():
		dialog_confirmed.emit(id)
		accept_dialog.queue_free()
	)
	accept_dialog.canceled.connect(func ():
		dialog_canceled.emit(id)
		accept_dialog.queue_free()
	)
	
	add_child(accept_dialog)
	accept_dialog.show()
	
	dialog_id += 1
	return id

func push_accept_question(msg : String, title: String = "Question") -> int:
	var accept_dialog := NativeAcceptDialog.new()
	accept_dialog.dialog_icon = NativeAcceptDialog.ICON_QUESTION
	accept_dialog.title = title
	accept_dialog.dialog_text = msg
	
	var id := dialog_id
	accept_dialog.confirmed.connect(func ():
		dialog_confirmed.emit(id)
		accept_dialog.queue_free()
	)
	accept_dialog.canceled.connect(func ():
		dialog_canceled.emit(id)
		accept_dialog.queue_free()
	)
	
	add_child(accept_dialog)
	accept_dialog.show()
	
	dialog_id += 1
	return id

func push_accept_error(msg : String, title: String = "Error") -> int:
	var accept_dialog := NativeAcceptDialog.new()
	accept_dialog.dialog_icon = NativeAcceptDialog.ICON_ERROR
	accept_dialog.title = title
	accept_dialog.dialog_text = msg
	
	var id := dialog_id
	accept_dialog.confirmed.connect(func ():
		dialog_confirmed.emit(id)
		accept_dialog.queue_free()
	)
	accept_dialog.canceled.connect(func ():
		dialog_canceled.emit(id)
		accept_dialog.queue_free()
	)
	
	add_child(accept_dialog)
	accept_dialog.show()
	
	dialog_id += 1
	return id

func push_accept_warning(msg : String, title: String = "Warning") -> int:
	var accept_dialog := NativeAcceptDialog.new()
	accept_dialog.dialog_icon = NativeAcceptDialog.ICON_WARNING
	accept_dialog.title = title
	accept_dialog.dialog_text = msg
	
	var id := dialog_id
	accept_dialog.confirmed.connect(func ():
		dialog_confirmed.emit(id)
		accept_dialog.queue_free()
	)
	accept_dialog.canceled.connect(func ():
		dialog_canceled.emit(id)
		accept_dialog.queue_free()
	)
	
	add_child(accept_dialog)
	accept_dialog.show()
	
	dialog_id += 1
	return id
	
func push_confirmation(msg : String, title: String = "Question", buttons_texts: int = 0) -> int:
	var accept_dialog := NativeConfirmationDialog.new()
	accept_dialog.title = title
	accept_dialog.dialog_text = msg
	accept_dialog.buttons_texts = buttons_texts
	
	var id := dialog_id
	accept_dialog.confirmed.connect(func ():
		dialog_confirmed.emit(id)
		accept_dialog.queue_free()
	)
	accept_dialog.canceled.connect(func ():
		dialog_canceled.emit(id)
		accept_dialog.queue_free()
	)
	
	add_child(accept_dialog)
	accept_dialog.show()
	
	dialog_id += 1
	return id
	
func notify_info(msg : String, title: String = "Info") -> void:
	var n = NativeNotification.new()
	n.notification_icon = NativeNotification.ICON_INFO
	n.notification_text = msg
	n.title = title
	
	add_child(n)
	n.send()

func notify_warning(msg : String, title: String = "Info") -> void:
	var n = NativeNotification.new()
	n.notification_icon = NativeNotification.ICON_WARNING
	n.notification_text = msg
	n.title = title
	
	add_child(n)
	n.send()

func notify_error(msg : String, title: String = "Info") -> void:
	var n = NativeNotification.new()
	n.notification_icon = NativeNotification.ICON_ERROR
	n.notification_text = msg
	n.title = title
	
	add_child(n)
	n.send()
