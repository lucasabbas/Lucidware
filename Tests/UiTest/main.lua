print("Hello, World!")

local doc = ui.document.__new(ioCore)
rootNode:addChild(doc)
doc:load("app://test.xml")

local label = doc:getObject("Panel/VBoxContainer/Control/Label")
local button = doc:getObject("Panel/VBoxContainer/Control/Button")

local counter = 0

function myOnClickEvent()
    counter = counter + 1
    label.text = "You clicked me " .. counter .. " times!"
end

button.pressed.add(myOnClickEvent)