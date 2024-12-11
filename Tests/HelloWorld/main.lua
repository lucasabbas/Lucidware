local sayHello = require "app://sayHello.lua"
require "app://class.lua"

local message = "Hello, World!"

print(message)

local number = 0

local ioCoreMulti = sys.IoCoreMulti()

sayHello("mintkat")

local Vector2 = class()
Vector2.x = 0
Vector2.y = 0

function Vector2:new(x, y)
    local o = {}
    setmetatable(o, self)
    self.__index = self
    o.x = x
    o.y = y
    return o
end

function Vector2:toString()
    return "Vector2: " .. self.x .. ", " .. self.y
end

local Vector3 = class(Vector2)
Vector3.z = 0

function Vector3:new(x, y, z)
    local o = Vector2.new(self, x, y)
    setmetatable(o, self)
    self.__index = self
    o.z = z
    return o
end

function Vector3:toString()
    return "Vector3: " .. self.x .. ", " .. self.y .. ", " .. self.z
end

local v2 = Vector2:new(1, 2)
local v3 = Vector3:new(1, 2, 3)

print(v2:toString())
print(v3:toString())

function update(deltaTime)
    print("update", deltaTime)
    number = number + 0.001
end

local gv3_1 = godot.Vector3.__new(1, 2, 3);
local gv3_2 = godot.Vector3.__new(3, 2, 1);

local gv3_combined = gv3_1 + gv3_2;

print(gv3_combined)

update(0)
