import { sayHello } from "assets://helloScript.js"

console.log("Hello");

RootNode.add_Main(function() {
    console.log("Hello from test.js");
    sayHello("mintkat");
    console.log(6 + 4);
    const vec3 = new Vector3(5, 3, 2);
    console.log(vec3);
    const meshInstance = new MeshInstance3D();
    const camera = new FreeLookCamera3D();
    const cameraPos = new Vector3(0,0, RootNode.doubleToFloat(2.799));
    RootNode.addChild(camera);
    camera.position = cameraPos;
    camera.current = true;
    const boxMesh = new BoxMesh();
    meshInstance.mesh = boxMesh;
    RootNode.addChild(meshInstance);
    const directionalLight = new DirectionalLight3D();
    RootNode.addChild(directionalLight);
});