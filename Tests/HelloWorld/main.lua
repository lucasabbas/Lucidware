local sayHello = require "app://sayHello.lua"

local message = "Hello, World!"

print(message)

local number = 0

local ioCoreMulti = sys.IoCoreMulti()

sayHello("mintkat")

while true do
    number = number + 0.001  
end