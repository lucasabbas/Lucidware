local sayHello = require "app://sayHello.lua"

local message = "Hello, World!"

print(message)

local number = 0

local ioCoreMulti = sys.IoCoreMulti()

sayHello("mintkat")

function update(deltaTime)
    print("update", deltaTime)
    number = number + 0.001
end

update(0)
