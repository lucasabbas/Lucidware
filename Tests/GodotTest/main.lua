local vec3 = godot.Vector3.__new(5, 3, 2)
print(vec3)

local meshInstance = godot.MeshInstance3D.__new()
local camera = gdx.FreeLookCamera3D.__new()
local cameraPos = godot.Vector3.__new(0, 0, 2.799)
rootNode.addChild(camera)
camera.position = cameraPos
camera.current = true
local boxMesh = godot.BoxMesh.__new()
meshInstance.mesh = boxMesh
rootNode.addChild(meshInstance)
local directionalLight = godot.DirectionalLight3D.__new()
rootNode.addChild(directionalLight)
