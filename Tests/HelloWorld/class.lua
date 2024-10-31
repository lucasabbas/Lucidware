BaseObject = {}
BaseObject.__index = BaseObject

function class(...)
    local object
    local args = { ... }
    if (#args == 0) then
        object = BaseObject
    else
        if (#args == 1) then
            object = args[1]
        else
            error("Invalid number of arguments")
        end
    end
    local table = {}
    table.__index = table
    setmetatable(table, object)
    table.instance = table
    return table
end

function BaseObject:new()
    local o = {}
    setmetatable(o, self)
    self.__index = self
    return o
end
