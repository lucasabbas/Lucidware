using System.Reflection;
using Godot;
using MoonSharp.Interpreter;
using Timer = Godot.Timer;
using GodotScript = Godot.Script;

namespace Lucidware.Core.Modules;

public class GodotModule : Module
{
    public GodotModule(LuaEnviroment luaEnviroment) : base(luaEnviroment)
    {
    }
    
    public override void Init()
    {
        Table GdCoreNamespace = new Table(LuaEnviroment.Script);
        LuaEnviroment.Script.Globals["godot"] = GdCoreNamespace;
        
        UserData.RegisterType(typeof(AudioServer));
        UserData.RegisterType(typeof(CameraServer));
        UserData.RegisterType(typeof(DisplayServer));
        UserData.RegisterType(typeof(NavigationServer2D));
        UserData.RegisterType(typeof(NavigationServer3D));
        UserData.RegisterType(typeof(OpenXRExtensionWrapperExtension));
        UserData.RegisterType(typeof(OpenXRInteractionProfileMetadata));
        UserData.RegisterType(typeof(PhysicsDirectBodyState2D));
        UserData.RegisterType(typeof(PhysicsDirectSpaceState2D));
        UserData.RegisterType(typeof(PhysicsServer2D));
        UserData.RegisterType(typeof(PhysicsServer2DManager));
        UserData.RegisterType(typeof(PhysicsDirectBodyState3D));
        UserData.RegisterType(typeof(PhysicsDirectSpaceState3D));
        UserData.RegisterType(typeof(PhysicsServer3D));
        UserData.RegisterType(typeof(PhysicsServer3DManager));
        UserData.RegisterType(typeof(RefCounted));
        UserData.RegisterType(typeof(RenderingDevice));
        UserData.RegisterType(typeof(RenderingServer));
        UserData.RegisterType(typeof(ThemeDB));
        UserData.RegisterType(typeof(Time));
        UserData.RegisterType(typeof(TranslationServer));
        UserData.RegisterType(typeof(UndoRedo));
        UserData.RegisterType(typeof(XRServer));

        GdCoreNamespace[nameof(AudioServer)] = UserData.CreateStatic(typeof(AudioServer));
        GdCoreNamespace[nameof(CameraServer)] = UserData.CreateStatic(typeof(CameraServer));
        GdCoreNamespace[nameof(DisplayServer)] = UserData.CreateStatic(typeof(DisplayServer));
        GdCoreNamespace[nameof(NavigationServer2D)] = UserData.CreateStatic(typeof(NavigationServer2D));
        GdCoreNamespace[nameof(NavigationServer3D)] = UserData.CreateStatic(typeof(NavigationServer3D));
        GdCoreNamespace[nameof(OpenXRExtensionWrapperExtension)] = UserData.CreateStatic(typeof(OpenXRExtensionWrapperExtension));
        GdCoreNamespace[nameof(OpenXRInteractionProfileMetadata)] = UserData.CreateStatic(typeof(OpenXRInteractionProfileMetadata));
        GdCoreNamespace[nameof(PhysicsDirectBodyState2D)] = UserData.CreateStatic(typeof(PhysicsDirectBodyState2D));
        GdCoreNamespace[nameof(PhysicsDirectSpaceState2D)] = UserData.CreateStatic(typeof(PhysicsDirectSpaceState2D));
        GdCoreNamespace[nameof(PhysicsServer2D)] = UserData.CreateStatic(typeof(PhysicsServer2D));
        GdCoreNamespace[nameof(PhysicsServer2DManager)] = UserData.CreateStatic(typeof(PhysicsServer2DManager));
        GdCoreNamespace[nameof(PhysicsDirectBodyState3D)] = UserData.CreateStatic(typeof(PhysicsDirectBodyState3D));
        GdCoreNamespace[nameof(PhysicsDirectSpaceState3D)] = UserData.CreateStatic(typeof(PhysicsDirectSpaceState3D));
        GdCoreNamespace[nameof(PhysicsServer3D)] = UserData.CreateStatic(typeof(PhysicsServer3D));
        GdCoreNamespace[nameof(PhysicsServer3DManager)] = UserData.CreateStatic(typeof(PhysicsServer3DManager));
        GdCoreNamespace[nameof(RenderingDevice)] = UserData.CreateStatic(typeof(RenderingDevice));
        GdCoreNamespace[nameof(RenderingServer)] = UserData.CreateStatic(typeof(RenderingServer));
        GdCoreNamespace[nameof(ThemeDB)] = UserData.CreateStatic(typeof(ThemeDB));
        GdCoreNamespace[nameof(Time)] = UserData.CreateStatic(typeof(Time));
        GdCoreNamespace[nameof(TranslationServer)] = UserData.CreateStatic(typeof(TranslationServer));
        GdCoreNamespace[nameof(UndoRedo)] = UserData.CreateStatic(typeof(UndoRedo));
        GdCoreNamespace[nameof(XRServer)] = UserData.CreateStatic(typeof(XRServer));


        UserData.RegisterType<Color>();
        UserData.RegisterType<Vector3>();
        UserData.RegisterType<Vector2>();
        UserData.RegisterType<Rect2>();
        UserData.RegisterType<Basis>();
        UserData.RegisterType<Transform2D>();
        UserData.RegisterType<Transform3D>();
        UserData.RegisterType<Plane>();
        UserData.RegisterType<Quaternion>();
        UserData.RegisterType<Aabb>();
        UserData.RegisterType<Node>();
        UserData.RegisterType<AnimationPlayer>();
        UserData.RegisterType<AnimationTree>();
        UserData.RegisterType<AudioStreamPlayer>();
        UserData.RegisterType<CanvasLayer>();
        UserData.RegisterType<ParallaxBackground>();
        UserData.RegisterType<HttpRequest>();
        UserData.RegisterType<NavigationAgent2D>();
        UserData.RegisterType<NavigationAgent3D>();
        UserData.RegisterType<ShaderGlobalsOverride>();
        UserData.RegisterType<StatusIndicator>();
        UserData.RegisterType<Timer>();
        UserData.RegisterType<SubViewport>();
        UserData.RegisterType<Window>();
        UserData.RegisterType<AcceptDialog>();
        UserData.RegisterType<ConfirmationDialog>();
        UserData.RegisterType<FileDialog>();
        UserData.RegisterType<Popup>();
        UserData.RegisterType<PopupMenu>();
        UserData.RegisterType<PopupPanel>();
        UserData.RegisterType<WorldEnvironment>();
        UserData.RegisterType<Control>();
        UserData.RegisterType<Button>();
        UserData.RegisterType<CheckBox>();
        UserData.RegisterType<CheckButton>();
        UserData.RegisterType<ColorPickerButton>();
        UserData.RegisterType<MenuButton>();
        UserData.RegisterType<OptionButton>();
        UserData.RegisterType<LinkButton>();
        UserData.RegisterType<TextureButton>();
        UserData.RegisterType<ColorRect>();
        UserData.RegisterType<Container>();
        UserData.RegisterType<AspectRatioContainer>();
        UserData.RegisterType<BoxContainer>();
        UserData.RegisterType<HBoxContainer>();
        UserData.RegisterType<VBoxContainer>();
        UserData.RegisterType<ColorPicker>();
        UserData.RegisterType<CenterContainer>();
        UserData.RegisterType<FlowContainer>();
        UserData.RegisterType<HFlowContainer>();
        UserData.RegisterType<VFlowContainer>();
        UserData.RegisterType<GraphElement>();
        UserData.RegisterType<GridContainer>();
        UserData.RegisterType<MarginContainer>();
        UserData.RegisterType<PanelContainer>();
        UserData.RegisterType<ScrollContainer>();
        UserData.RegisterType<SplitContainer>();
        UserData.RegisterType<HSplitContainer>();
        UserData.RegisterType<VSplitContainer>();
        UserData.RegisterType<SubViewportContainer>();
        UserData.RegisterType<TabContainer>();
        UserData.RegisterType<GraphEdit>();
        UserData.RegisterType<ItemList>();
        UserData.RegisterType<Label>();
        UserData.RegisterType<LineEdit>();
        UserData.RegisterType<MenuBar>();
        UserData.RegisterType<NinePatchRect>();
        UserData.RegisterType<Panel>();
        UserData.RegisterType<ReferenceRect>();
        UserData.RegisterType<RichTextLabel>();
        UserData.RegisterType<Godot.Range>();
        UserData.RegisterType<ProgressBar>();
        UserData.RegisterType<HScrollBar>();
        UserData.RegisterType<VScrollBar>();
        UserData.RegisterType<HSlider>();
        UserData.RegisterType<VSlider>();
        UserData.RegisterType<SpinBox>();
        UserData.RegisterType<TextureProgressBar>();
        UserData.RegisterType<HSeparator>();
        UserData.RegisterType<VSeparator>();
        UserData.RegisterType<TabBar>();
        UserData.RegisterType<TextureRect>();
        UserData.RegisterType<Tree>();
        UserData.RegisterType<VideoStreamPlayer>();
        UserData.RegisterType<Node2D>();
        UserData.RegisterType<AnimatedSprite2D>();
        UserData.RegisterType<AudioListener2D>();
        UserData.RegisterType<AudioStreamPlayer2D>();
        UserData.RegisterType<BackBufferCopy>();
        UserData.RegisterType<Bone2D>();
        UserData.RegisterType<Camera2D>();
        UserData.RegisterType<CanvasGroup>();
        UserData.RegisterType<CanvasModulate>();
        UserData.RegisterType<Area2D>();
        UserData.RegisterType<CharacterBody2D>();
        UserData.RegisterType<RigidBody2D>();
        UserData.RegisterType<PhysicalBone2D>();
        UserData.RegisterType<StaticBody2D>();
        UserData.RegisterType<AnimatableBody2D>();
        UserData.RegisterType<CollisionPolygon2D>();
        UserData.RegisterType<CollisionShape2D>();
        UserData.RegisterType<CpuParticles2D>();
        UserData.RegisterType<GpuParticles2D>();
        UserData.RegisterType<DampedSpringJoint2D>();
        UserData.RegisterType<GrooveJoint2D>();
        UserData.RegisterType<PinJoint2D>();
        UserData.RegisterType<DirectionalLight2D>();
        UserData.RegisterType<PointLight2D>();
        UserData.RegisterType<LightOccluder2D>();
        UserData.RegisterType<Line2D>();
        UserData.RegisterType<Marker2D>();
        UserData.RegisterType<MeshInstance2D>();
        UserData.RegisterType<MultiMeshInstance2D>();
        UserData.RegisterType<NavigationLink2D>();
        UserData.RegisterType<NavigationObstacle2D>();
        UserData.RegisterType<NavigationRegion2D>();
        UserData.RegisterType<Parallax2D>();
        UserData.RegisterType<ParallaxLayer>();
        UserData.RegisterType<Path2D>();
        UserData.RegisterType<PathFollow2D>();
        UserData.RegisterType<Polygon2D>();
        UserData.RegisterType<RayCast2D>();
        UserData.RegisterType<RemoteTransform2D>();
        UserData.RegisterType<ShapeCast2D>();
        UserData.RegisterType<Skeleton2D>();
        UserData.RegisterType<Sprite2D>();
        UserData.RegisterType<TileMap>();
        UserData.RegisterType<TileMapLayer>();
        UserData.RegisterType<TouchScreenButton>();
        UserData.RegisterType<VisibleOnScreenNotifier2D>();
        UserData.RegisterType<VisibleOnScreenEnabler2D>();
        UserData.RegisterType<Node3D>();
        UserData.RegisterType<AudioListener3D>();
        UserData.RegisterType<AudioStreamPlayer3D>();
        UserData.RegisterType<BoneAttachment3D>();
        UserData.RegisterType<Camera3D>();
        UserData.RegisterType<XRCamera3D>();
        UserData.RegisterType<Area3D>();
        UserData.RegisterType<CharacterBody3D>();
        UserData.RegisterType<PhysicalBone3D>();
        UserData.RegisterType<RigidBody3D>();
        UserData.RegisterType<VehicleBody3D>();
        UserData.RegisterType<StaticBody3D>();
        UserData.RegisterType<AnimatableBody3D>();
        UserData.RegisterType<CollisionPolygon3D>();
        UserData.RegisterType<CollisionShape3D>();
        UserData.RegisterType<GridMap>();
        UserData.RegisterType<ImporterMeshInstance3D>();
        UserData.RegisterType<ConeTwistJoint3D>();
        UserData.RegisterType<Generic6DofJoint3D>();
        UserData.RegisterType<HingeJoint3D>();
        UserData.RegisterType<PinJoint3D>();
        UserData.RegisterType<SliderJoint3D>();
        UserData.RegisterType<LightmapProbe>();
        UserData.RegisterType<Marker3D>();
        UserData.RegisterType<NavigationLink3D>();
        UserData.RegisterType<NavigationObstacle3D>();
        UserData.RegisterType<NavigationRegion3D>();
        UserData.RegisterType<OpenXRCompositionLayerCylinder>();
        UserData.RegisterType<OpenXRCompositionLayerEquirect>();
        UserData.RegisterType<OpenXRCompositionLayerQuad>();
        UserData.RegisterType<Path3D>();
        UserData.RegisterType<PathFollow3D>();
        UserData.RegisterType<RayCast3D>();
        UserData.RegisterType<RemoteTransform3D>();
        UserData.RegisterType<ShapeCast3D>();
        UserData.RegisterType<Skeleton3D>();
        UserData.RegisterType<SkeletonModifier3D>();
        UserData.RegisterType<SpringArm3D>();
        UserData.RegisterType<VehicleWheel3D>();
        UserData.RegisterType<VisualInstance3D>();
        UserData.RegisterType<Decal>();
        UserData.RegisterType<FogVolume>();
        UserData.RegisterType<GeometryInstance3D>();
        UserData.RegisterType<CpuParticles3D>();
        UserData.RegisterType<CsgCombiner3D>();
        UserData.RegisterType<CsgBox3D>();
        UserData.RegisterType<CsgCylinder3D>();
        UserData.RegisterType<CsgMesh3D>();
        UserData.RegisterType<CsgPolygon3D>();
        UserData.RegisterType<CsgSphere3D>();
        UserData.RegisterType<CsgTorus3D>();
        UserData.RegisterType<GpuParticles3D>();
        UserData.RegisterType<Label3D>();
        UserData.RegisterType<MeshInstance3D>();
        UserData.RegisterType<SoftBody3D>();
        UserData.RegisterType<MultiMeshInstance3D>();
        UserData.RegisterType<Sprite3D>();
        UserData.RegisterType<AnimatedSprite3D>();
        UserData.RegisterType<GpuParticlesAttractorBox3D>();
        UserData.RegisterType<GpuParticlesAttractorSphere3D>();
        UserData.RegisterType<GpuParticlesAttractorVectorField3D>();
        UserData.RegisterType<GpuParticlesCollisionBox3D>();
        UserData.RegisterType<GpuParticlesCollisionHeightField3D>();
        UserData.RegisterType<GpuParticlesCollisionSdf3D>();
        UserData.RegisterType<GpuParticlesCollisionSphere3D>();
        UserData.RegisterType<Light3D>();
        UserData.RegisterType<LightmapProbe>();
        UserData.RegisterType<Marker3D>();
        UserData.RegisterType<NavigationLink3D>();
        UserData.RegisterType<NavigationObstacle3D>();
        UserData.RegisterType<NavigationRegion3D>();
        UserData.RegisterType<OpenXRCompositionLayerCylinder>();
        UserData.RegisterType<OpenXRCompositionLayerEquirect>();
        UserData.RegisterType<OpenXRCompositionLayerQuad>();
        UserData.RegisterType<Path3D>();
        UserData.RegisterType<PathFollow3D>();
        UserData.RegisterType<RayCast3D>();
        UserData.RegisterType<RemoteTransform3D>();
        UserData.RegisterType<ShapeCast3D>();
        UserData.RegisterType<Skeleton3D>();
        UserData.RegisterType<SkeletonModifier3D>();
        UserData.RegisterType<SpringArm3D>();
        UserData.RegisterType<VehicleWheel3D>();
        UserData.RegisterType<VisualInstance3D>();
        UserData.RegisterType<Decal>();
        UserData.RegisterType<FogVolume>();
        UserData.RegisterType<GeometryInstance3D>();
        UserData.RegisterType<CpuParticles3D>();
        UserData.RegisterType<CsgCombiner3D>();
        UserData.RegisterType<CsgBox3D>();
        UserData.RegisterType<CsgCylinder3D>();
        UserData.RegisterType<CsgMesh3D>();
        UserData.RegisterType<CsgPolygon3D>();
        UserData.RegisterType<CsgSphere3D>();
        UserData.RegisterType<CsgTorus3D>();
        UserData.RegisterType<GpuParticles3D>();
        UserData.RegisterType<Label3D>();
        UserData.RegisterType<MeshInstance3D>();
        UserData.RegisterType<SoftBody3D>();
        UserData.RegisterType<MultiMeshInstance3D>();
        UserData.RegisterType<Sprite3D>();
        UserData.RegisterType<AnimatedSprite3D>();
        UserData.RegisterType<GpuParticlesAttractorBox3D>();
        UserData.RegisterType<GpuParticlesAttractorSphere3D>();
        UserData.RegisterType<GpuParticlesAttractorVectorField3D>();
        UserData.RegisterType<GpuParticlesCollisionBox3D>();
        UserData.RegisterType<GpuParticlesCollisionHeightField3D>();
        UserData.RegisterType<GpuParticlesCollisionSdf3D>();
        UserData.RegisterType<GpuParticlesCollisionSphere3D>();
        UserData.RegisterType<Light3D>();
        UserData.RegisterType<LightmapProbe>();
        UserData.RegisterType<DirectionalLight3D>();
        UserData.RegisterType<OmniLight3D>();
        UserData.RegisterType<SpotLight3D>();
        UserData.RegisterType<LightmapGI>();
        UserData.RegisterType<OccluderInstance3D>();
        UserData.RegisterType<ReflectionProbe>();
        UserData.RegisterType<VisibleOnScreenNotifier3D>();
        UserData.RegisterType<VisibleOnScreenEnabler3D>();
        UserData.RegisterType<VoxelGI>();
        UserData.RegisterType<XRFaceModifier3D>();
        UserData.RegisterType<XRHandModifier3D>();
        UserData.RegisterType<XRNode3D>();
        UserData.RegisterType<XRController3D>();
        UserData.RegisterType<XRAnchor3D>();
        UserData.RegisterType<XROrigin3D>();
        
        GdCoreNamespace["Color"] = typeof(Color);
        GdCoreNamespace["Vector3"] = typeof(Vector3);
        GdCoreNamespace["Vector2"] = typeof(Vector2);
        GdCoreNamespace["Rect2"] = typeof(Rect2);
        GdCoreNamespace["Basis"] = typeof(Basis);
        GdCoreNamespace["Transform2D"] = typeof(Transform2D);
        GdCoreNamespace["Transform3D"] = typeof(Transform3D);
        GdCoreNamespace["Plane"] = typeof(Plane);
        GdCoreNamespace["Quaternion"] = typeof(Quaternion);
        GdCoreNamespace["Aabb"] = typeof(Aabb);
        GdCoreNamespace["Node"] = typeof(Node);
        GdCoreNamespace["AnimationPlayer"] = typeof(AnimationPlayer);
        GdCoreNamespace["AnimationTree"] = typeof(AnimationTree);
        GdCoreNamespace["AudioStreamPlayer"] = typeof(AudioStreamPlayer);
        GdCoreNamespace["CanvasLayer"] = typeof(CanvasLayer);
        GdCoreNamespace["ParallaxBackground"] = typeof(ParallaxBackground);
        GdCoreNamespace["HttpRequest"] = typeof(HttpRequest);
        GdCoreNamespace["NavigationAgent2D"] = typeof(NavigationAgent2D);
        GdCoreNamespace["NavigationAgent3D"] = typeof(NavigationAgent3D);
        GdCoreNamespace["ShaderGlobalsOverride"] = typeof(ShaderGlobalsOverride);
        GdCoreNamespace["StatusIndicator"] = typeof(StatusIndicator);
        GdCoreNamespace["Timer"] = typeof(Timer);
        GdCoreNamespace["SubViewport"] = typeof(SubViewport);
        GdCoreNamespace["Window"] = typeof(Window);
        GdCoreNamespace["AcceptDialog"] = typeof(AcceptDialog);
        GdCoreNamespace["ConfirmationDialog"] = typeof(ConfirmationDialog);
        GdCoreNamespace["FileDialog"] = typeof(FileDialog);
        GdCoreNamespace["Popup"] = typeof(Popup);
        GdCoreNamespace["PopupMenu"] = typeof(PopupMenu);
        GdCoreNamespace["PopupPanel"] = typeof(PopupPanel);
        GdCoreNamespace["WorldEnvironment"] = typeof(WorldEnvironment);
        GdCoreNamespace["Control"] = typeof(Control);
        GdCoreNamespace["Button"] = typeof(Button);
        GdCoreNamespace["CheckBox"] = typeof(CheckBox);
        GdCoreNamespace["CheckButton"] = typeof(CheckButton);
        GdCoreNamespace["ColorPickerButton"] = typeof(ColorPickerButton);
        GdCoreNamespace["MenuButton"] = typeof(MenuButton);
        GdCoreNamespace["OptionButton"] = typeof(OptionButton);
        GdCoreNamespace["LinkButton"] = typeof(LinkButton);
        GdCoreNamespace["TextureButton"] = typeof(TextureButton);
        GdCoreNamespace["ColorRect"] = typeof(ColorRect);
        GdCoreNamespace["Container"] = typeof(Container);
        GdCoreNamespace["AspectRatioContainer"] = typeof(AspectRatioContainer);
        GdCoreNamespace["BoxContainer"] = typeof(BoxContainer);
        GdCoreNamespace["HBoxContainer"] = typeof(HBoxContainer);
        GdCoreNamespace["VBoxContainer"] = typeof(VBoxContainer);
        GdCoreNamespace["ColorPicker"] = typeof(ColorPicker);
        GdCoreNamespace["CenterContainer"] = typeof(CenterContainer);
        GdCoreNamespace["FlowContainer"] = typeof(FlowContainer);
        GdCoreNamespace["HFlowContainer"] = typeof(HFlowContainer);
        GdCoreNamespace["VFlowContainer"] = typeof(VFlowContainer);
        GdCoreNamespace["GraphElement"] = typeof(GraphElement);
        GdCoreNamespace["GridContainer"] = typeof(GridContainer);
        GdCoreNamespace["MarginContainer"] = typeof(MarginContainer);
        GdCoreNamespace["PanelContainer"] = typeof(PanelContainer);
        GdCoreNamespace["ScrollContainer"] = typeof(ScrollContainer);
        GdCoreNamespace["SplitContainer"] = typeof(SplitContainer);
        GdCoreNamespace["HSplitContainer"] = typeof(HSplitContainer);
        GdCoreNamespace["VSplitContainer"] = typeof(VSplitContainer);
        GdCoreNamespace["SubViewportContainer"] = typeof(SubViewportContainer);
        GdCoreNamespace["TabContainer"] = typeof(TabContainer);
        GdCoreNamespace["GraphEdit"] = typeof(GraphEdit);
        GdCoreNamespace["ItemList"] = typeof(ItemList);
        GdCoreNamespace["Label"] = typeof(Label);
        GdCoreNamespace["LineEdit"] = typeof(LineEdit);
        GdCoreNamespace["MenuBar"] = typeof(MenuBar);
        GdCoreNamespace["NinePatchRect"] = typeof(NinePatchRect);
        GdCoreNamespace["Panel"] = typeof(Panel);
        GdCoreNamespace["ReferenceRect"] = typeof(ReferenceRect);
        GdCoreNamespace["RichTextLabel"] = typeof(RichTextLabel);
        GdCoreNamespace["Range"] = typeof(Godot.Range);
        GdCoreNamespace["ProgressBar"] = typeof(ProgressBar);
        GdCoreNamespace["HScrollBar"] = typeof(HScrollBar);
        GdCoreNamespace["VScrollBar"] = typeof(VScrollBar);
        GdCoreNamespace["HSlider"] = typeof(HSlider);
        GdCoreNamespace["VSlider"] = typeof(VSlider);
        GdCoreNamespace["SpinBox"] = typeof(SpinBox);
        GdCoreNamespace["TextureProgressBar"] = typeof(TextureProgressBar);
        GdCoreNamespace["HSeparator"] = typeof(HSeparator);
        GdCoreNamespace["VSeparator"] = typeof(VSeparator);
        GdCoreNamespace["TabBar"] = typeof(TabBar);
        GdCoreNamespace["TextureRect"] = typeof(TextureRect);
        GdCoreNamespace["Tree"] = typeof(Tree);
        GdCoreNamespace["VideoStreamPlayer"] = typeof(VideoStreamPlayer);
        GdCoreNamespace["Node2D"] = typeof(Node2D);
        GdCoreNamespace["AnimatedSprite2D"] = typeof(AnimatedSprite2D);
        GdCoreNamespace["AudioListener2D"] = typeof(AudioListener2D);
        GdCoreNamespace["AudioStreamPlayer2D"] = typeof(AudioStreamPlayer2D);
        GdCoreNamespace["BackBufferCopy"] = typeof(BackBufferCopy);
        GdCoreNamespace["Bone2D"] = typeof(Bone2D);
        GdCoreNamespace["Camera2D"] = typeof(Camera2D);
        GdCoreNamespace["CanvasGroup"] = typeof(CanvasGroup);
        GdCoreNamespace["CanvasModulate"] = typeof(CanvasModulate);
        GdCoreNamespace["Area2D"] = typeof(Area2D);
        GdCoreNamespace["CharacterBody2D"] = typeof(CharacterBody2D);
        GdCoreNamespace["RigidBody2D"] = typeof(RigidBody2D);
        GdCoreNamespace["PhysicalBone2D"] = typeof(PhysicalBone2D);
        GdCoreNamespace["StaticBody2D"] = typeof(StaticBody2D);
        GdCoreNamespace["AnimatableBody2D"] = typeof(AnimatableBody2D);
        GdCoreNamespace["CollisionPolygon2D"] = typeof(CollisionPolygon2D);
        GdCoreNamespace["CollisionShape2D"] = typeof(CollisionShape2D);
        GdCoreNamespace["CpuParticles2D"] = typeof(CpuParticles2D);
        GdCoreNamespace["GpuParticles2D"] = typeof(GpuParticles2D);
        GdCoreNamespace["DampedSpringJoint2D"] = typeof(DampedSpringJoint2D);
        GdCoreNamespace["GrooveJoint2D"] = typeof(GrooveJoint2D);
        GdCoreNamespace["PinJoint2D"] = typeof(PinJoint2D);
        GdCoreNamespace["DirectionalLight2D"] = typeof(DirectionalLight2D);
        GdCoreNamespace["PointLight2D"] = typeof(PointLight2D);
        GdCoreNamespace["LightOccluder2D"] = typeof(LightOccluder2D);
        GdCoreNamespace["Line2D"] = typeof(Line2D);
        GdCoreNamespace["Marker2D"] = typeof(Marker2D);
        GdCoreNamespace["MeshInstance2D"] = typeof(MeshInstance2D);
        GdCoreNamespace["MultiMeshInstance2D"] = typeof(MultiMeshInstance2D);
        GdCoreNamespace["NavigationLink2D"] = typeof(NavigationLink2D);
        GdCoreNamespace["NavigationObstacle2D"] = typeof(NavigationObstacle2D);
        GdCoreNamespace["NavigationRegion2D"] = typeof(NavigationRegion2D);
        GdCoreNamespace["Parallax2D"] = typeof(Parallax2D);
        GdCoreNamespace["ParallaxLayer"] = typeof(ParallaxLayer);
        GdCoreNamespace["Path2D"] = typeof(Path2D);
        GdCoreNamespace["PathFollow2D"] = typeof(PathFollow2D);
        GdCoreNamespace["Polygon2D"] = typeof(Polygon2D);
        GdCoreNamespace["RayCast2D"] = typeof(RayCast2D);
        GdCoreNamespace["RemoteTransform2D"] = typeof(RemoteTransform2D);
        GdCoreNamespace["ShapeCast2D"] = typeof(ShapeCast2D);
        GdCoreNamespace["Skeleton2D"] = typeof(Skeleton2D);
        GdCoreNamespace["Sprite2D"] = typeof(Sprite2D);
        GdCoreNamespace["TileMap"] = typeof(TileMap);
        GdCoreNamespace["TileMapLayer"] = typeof(TileMapLayer);
        GdCoreNamespace["TouchScreenButton"] = typeof(TouchScreenButton);
        GdCoreNamespace["VisibleOnScreenNotifier2D"] = typeof(VisibleOnScreenNotifier2D);
        GdCoreNamespace["VisibleOnScreenEnabler2D"] = typeof(VisibleOnScreenEnabler2D);
        GdCoreNamespace["Node3D"] = typeof(Node3D);
        GdCoreNamespace["AudioListener3D"] = typeof(AudioListener3D);
        GdCoreNamespace["AudioStreamPlayer3D"] = typeof(AudioStreamPlayer3D);
        GdCoreNamespace["BoneAttachment3D"] = typeof(BoneAttachment3D);
        GdCoreNamespace["Camera3D"] = typeof(Camera3D);
        GdCoreNamespace["XRCamera3D"] = typeof(XRCamera3D);
        GdCoreNamespace["Area3D"] = typeof(Area3D);
        GdCoreNamespace["CharacterBody3D"] = typeof(CharacterBody3D);
        GdCoreNamespace["PhysicalBone3D"] = typeof(PhysicalBone3D);
        GdCoreNamespace["RigidBody3D"] = typeof(RigidBody3D);
        GdCoreNamespace["VehicleBody3D"] = typeof(VehicleBody3D);
        GdCoreNamespace["StaticBody3D"] = typeof(StaticBody3D);
        GdCoreNamespace["AnimatableBody3D"] = typeof(AnimatableBody3D);
        GdCoreNamespace["CollisionPolygon3D"] = typeof(CollisionPolygon3D);
        GdCoreNamespace["CollisionShape3D"] = typeof(CollisionShape3D);
        GdCoreNamespace["GridMap"] = typeof(GridMap);
        GdCoreNamespace["ImporterMeshInstance3D"] = typeof(ImporterMeshInstance3D);
        GdCoreNamespace["ConeTwistJoint3D"] = typeof(ConeTwistJoint3D);
        GdCoreNamespace["Generic6DofJoint3D"] = typeof(Generic6DofJoint3D);
        GdCoreNamespace["HingeJoint3D"] = typeof(HingeJoint3D);
        GdCoreNamespace["PinJoint3D"] = typeof(PinJoint3D);
        GdCoreNamespace["SliderJoint3D"] = typeof(SliderJoint3D);
        GdCoreNamespace["LightmapProbe"] = typeof(LightmapProbe);
        GdCoreNamespace["Marker3D"] = typeof(Marker3D);
        GdCoreNamespace["NavigationLink3D"] = typeof(NavigationLink3D);
        GdCoreNamespace["NavigationObstacle3D"] = typeof(NavigationObstacle3D);
        GdCoreNamespace["NavigationRegion3D"] = typeof(NavigationRegion3D);
        GdCoreNamespace["OpenXRCompositionLayerCylinder"] = typeof(OpenXRCompositionLayerCylinder);
        GdCoreNamespace["OpenXRCompositionLayerEquirect"] = typeof(OpenXRCompositionLayerEquirect);
        GdCoreNamespace["OpenXRCompositionLayerQuad"] = typeof(OpenXRCompositionLayerQuad);
        GdCoreNamespace["Path3D"] = typeof(Path3D);
        GdCoreNamespace["PathFollow3D"] = typeof(PathFollow3D);
        GdCoreNamespace["RayCast3D"] = typeof(RayCast3D);
        GdCoreNamespace["RemoteTransform3D"] = typeof(RemoteTransform3D);
        GdCoreNamespace["ShapeCast3D"] = typeof(ShapeCast3D);
        GdCoreNamespace["Skeleton3D"] = typeof(Skeleton3D);
        GdCoreNamespace["SkeletonModifier3D"] = typeof(SkeletonModifier3D);
        GdCoreNamespace["SpringArm3D"] = typeof(SpringArm3D);
        GdCoreNamespace["VehicleWheel3D"] = typeof(VehicleWheel3D);
        GdCoreNamespace["VisualInstance3D"] = typeof(VisualInstance3D);
        GdCoreNamespace["Decal"] = typeof(Decal);
        GdCoreNamespace["FogVolume"] = typeof(FogVolume);
        GdCoreNamespace["GeometryInstance3D"] = typeof(GeometryInstance3D);
        GdCoreNamespace["CpuParticles3D"] = typeof(CpuParticles3D);
        GdCoreNamespace["CsgCombiner3D"] = typeof(CsgCombiner3D);
        GdCoreNamespace["CsgBox3D"] = typeof(CsgBox3D);
        GdCoreNamespace["CsgCylinder3D"] = typeof(CsgCylinder3D);
        GdCoreNamespace["CsgMesh3D"] = typeof(CsgMesh3D);
        GdCoreNamespace["CsgPolygon3D"] = typeof(CsgPolygon3D);
        GdCoreNamespace["CsgSphere3D"] = typeof(CsgSphere3D);
        GdCoreNamespace["CsgTorus3D"] = typeof(CsgTorus3D);
        GdCoreNamespace["GpuParticles3D"] = typeof(GpuParticles3D);
        GdCoreNamespace["Label3D"] = typeof(Label3D);
        GdCoreNamespace["MeshInstance3D"] = typeof(MeshInstance3D);
        GdCoreNamespace["SoftBody3D"] = typeof(SoftBody3D);
        GdCoreNamespace["MultiMeshInstance3D"] = typeof(MultiMeshInstance3D);
        GdCoreNamespace["Sprite3D"] = typeof(Sprite3D);
        GdCoreNamespace["AnimatedSprite3D"] = typeof(AnimatedSprite3D);
        GdCoreNamespace["GpuParticlesAttractorBox3D"] = typeof(GpuParticlesAttractorBox3D);
        GdCoreNamespace["GpuParticlesAttractorSphere3D"] = typeof(GpuParticlesAttractorSphere3D);
        GdCoreNamespace["GpuParticlesAttractorVectorField3D"] = typeof(GpuParticlesAttractorVectorField3D);
        GdCoreNamespace["GpuParticlesCollisionBox3D"] = typeof(GpuParticlesCollisionBox3D);
        GdCoreNamespace["GpuParticlesCollisionHeightField3D"] = typeof(GpuParticlesCollisionHeightField3D);
        GdCoreNamespace["GpuParticlesCollisionSdf3D"] = typeof(GpuParticlesCollisionSdf3D);
        GdCoreNamespace["GpuParticlesCollisionSphere3D"] = typeof(GpuParticlesCollisionSphere3D);
        GdCoreNamespace["Light3D"] = typeof(Light3D);
        GdCoreNamespace["LightmapProbe"] = typeof(LightmapProbe);
        GdCoreNamespace["DirectionalLight3D"] = typeof(DirectionalLight3D);
        GdCoreNamespace["OmniLight3D"] = typeof(OmniLight3D);
        GdCoreNamespace["SpotLight3D"] = typeof(SpotLight3D);
        GdCoreNamespace["LightmapGI"] = typeof(LightmapGI);
        GdCoreNamespace["OccluderInstance3D"] = typeof(OccluderInstance3D);
        GdCoreNamespace["ReflectionProbe"] = typeof(ReflectionProbe);
        GdCoreNamespace["VisibleOnScreenNotifier3D"] = typeof(VisibleOnScreenNotifier3D);
        GdCoreNamespace["VisibleOnScreenEnabler3D"] = typeof(VisibleOnScreenEnabler3D);
        GdCoreNamespace["VoxelGI"] = typeof(VoxelGI);
        GdCoreNamespace["XRFaceModifier3D"] = typeof(XRFaceModifier3D);
        GdCoreNamespace["XRHandModifier3D"] = typeof(XRHandModifier3D);
        GdCoreNamespace["XRNode3D"] = typeof(XRNode3D);
        GdCoreNamespace["XRController3D"] = typeof(XRController3D);
        GdCoreNamespace["XRAnchor3D"] = typeof(XRAnchor3D);
        GdCoreNamespace["XROrigin3D"] = typeof(XROrigin3D);

        foreach (var VARIABLE in GetTypesInheritedFrom(typeof(RefCounted)))
        {
            
        }
    }
    
    public static Type[] GetTypesInheritedFrom(Type baseType)
    {
        Assembly assembly = baseType.Assembly;
        Type[] types = assembly.GetTypes();
        Type[] inheritedTypes = types.Where(t => t.IsSubclassOf(baseType)).ToArray();
        return inheritedTypes;
    }
    
    public Type[] GetBlackListedTypes()
    {
        return new[]
        {
            typeof(GDExtension),
            typeof(GDScript),
            typeof(CSharpScript),
            typeof(GodotScript),
            typeof(DirAccess),
            typeof(ENetConnection),
            ,
        };
    }

    public bool IsBlackListedType(Type type)
    {
        return GetBlackListedTypes().Contains(type);
    }
    
    public Color Color(int r, int g, int b, int a)
    {
        return new Color(r, g, b, a);
    }
    
    public Vector3 Vector3(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    
    public Vector2 Vector2(float x, float y)
    {
        return new Vector2(x, y);
    }
    
    public Rect2 Rect2(float x, float y, float width, float height)
    {
        return new Rect2(x, y, width, height);
    }
    
    public Basis Basis(Vector3 x, Vector3 y, Vector3 z)
    {
        return new Basis(x, y, z);
    }
    
    public Transform2D Transform2D(float a, Vector2 b)
    {
        return new Transform2D(a, b);
    }
    
    public Transform3D Transform(Basis basis, Vector3 origin)
    {
        return new Transform3D(basis, origin);
    }
    
    public Plane Plane(Vector3 normal, float d)
    {
        return new Plane(normal, d);
    }
    
    public Quaternion Quaternion(float x, float y, float z, float w)
    {
        return new Quaternion(x, y, z, w);
    }
    
    public Aabb Aabb(Vector3 position, Vector3 size)
    {
        return new Aabb(position, size);
    }
    
    public Color ColorFromHex(string hex)
    {
        return new Color(hex);
    }
    
    public Vector3 Vector3FromLuaTable(Table table)
    {
        return new Vector3((float)table.Get(1).Number, (float)table.Get(2).Number, (float)table.Get(3).Number);
    }
    
    public Vector2 Vector2FromLuaTable(Table table)
    {
        return new Vector2((float)table.Get(1).Number, (float)table.Get(2).Number);
    }
    
    public Rect2 Rect2FromLuaTable(Table table)
    {
        return new Rect2((float)table.Get(1).Number, (float)table.Get(2).Number, (float)table.Get(3).Number, (float)table.Get(4).Number);
    }
    
    public Basis BasisFromLuaTable(Table table)
    {
        return new Basis(Vector3FromLuaTable((Table)table.Get(1).Table), Vector3FromLuaTable((Table)table.Get(2).Table), Vector3FromLuaTable((Table)table.Get(3).Table));
    }
    
    public Transform2D Transform2DFromLuaTable(Table table)
    {
        return new Transform2D((float)table.Get(1).Number, Vector2FromLuaTable((Table)table.Get(2).Table));
    }
    
    public Transform3D TransformFromLuaTable(Table table)
    {
        return new Transform3D(BasisFromLuaTable((Table)table.Get(1).Table), Vector3FromLuaTable((Table)table.Get(2).Table));
    }
    
    public Plane PlaneFromLuaTable(Table table)
    {
        return new Plane(Vector3FromLuaTable((Table)table.Get(1).Table), (float)table.Get(2).Number);
    }
    
    public Quaternion QuaternionFromLuaTable(Table table)
    {
        return new Quaternion((float)table.Get(1).Number, (float)table.Get(2).Number, (float)table.Get(3).Number, (float)table.Get(4).Number);
    }
    
    public Aabb AabbFromLuaTable(Table table)
    {
        return new Aabb(Vector3FromLuaTable((Table)table.Get(1).Table), Vector3FromLuaTable((Table)table.Get(2).Table));
    }

    public Node Node()
    {
        return new Node();
    }
    
    public AnimationPlayer AnimationPlayer()
    {
        return new AnimationPlayer();
    }
    
    public AnimationTree AnimationTree()
    {
        return new AnimationTree();
    }
    
    public AudioStreamPlayer AudioStreamPlayer()
    {
        return new AudioStreamPlayer();
    }
    
    public CanvasLayer CanvasLayer()
    {
        return new CanvasLayer();
    }
    
    public ParallaxBackground ParallaxBackground()
    {
        return new ParallaxBackground();
    }
    
    public HttpRequest HttpRequest()
    {
        return new HttpRequest();
    }
    
    public NavigationAgent2D NavigationAgent2D()
    {
        return new NavigationAgent2D();
    }
    
    public NavigationAgent3D NavigationAgent3D()
    {
        return new NavigationAgent3D();
    }
    
    public ShaderGlobalsOverride ShaderGlobalsOverride()
    {
        return new ShaderGlobalsOverride();
    }
    
    public StatusIndicator StatusIndicator()
    {
        return new StatusIndicator();
    }
    
    public Timer Timer()
    {
        return new Timer();
    }
    
    public SubViewport SubViewport()
    {
        return new SubViewport();
    }

    public Window Window()
    {
        return new Window();
    }
    
    public AcceptDialog AcceptDialog()
    {
        return new AcceptDialog();
    }
    
    public ConfirmationDialog ConfirmationDialog()
    {
        return new ConfirmationDialog();
    }
    
    public FileDialog FileDialog()
    {
        return new FileDialog();
    }
    
    public Popup Popup()
    {
        return new Popup();
    }
    
    public PopupMenu PopupMenu()
    {
        return new PopupMenu();
    }
    
    public PopupPanel PopupPanel()
    {
        return new PopupPanel();
    }
    
    public WorldEnvironment WorldEnvironment()
    {
        return new WorldEnvironment();
    }
    
    public Control Control()
    {
        return new Control();
    }
    
    public Button Button()
    {
        return new Button();
    }
    
    public CheckBox CheckBox()
    {
        return new CheckBox();
    }
    
    public CheckButton CheckButton()
    {
        return new CheckButton();
    }
    
    public ColorPickerButton ColorPickerButton()
    {
        return new ColorPickerButton();
    }
    
    public MenuButton MenuButton()
    {
        return new MenuButton();
    }
    
    public OptionButton OptionButton()
    {
        return new OptionButton();
    }
    
    public LinkButton LinkButton()
    {
        return new LinkButton();
    }
    
    public TextureButton TextureButton()
    {
        return new TextureButton();
    }
    
    public ColorRect ColorRect()
    {
        return new ColorRect();
    }
    
    public Container Container()
    {
        return new Container();
    }
    
    public AspectRatioContainer AspectRatioContainer()
    {
        return new AspectRatioContainer();
    }
    
    public BoxContainer BoxContainer()
    {
        return new BoxContainer();
    }
    
    public HBoxContainer HBoxContainer()
    {
        return new HBoxContainer();
    }
    
    public VBoxContainer VBoxContainer()
    {
        return new VBoxContainer();
    }
    
    public ColorPicker ColorPicker()
    {
        return new ColorPicker();
    }
    
    public CenterContainer CenterContainer()
    {
        return new CenterContainer();
    }
    
    public FlowContainer FlowContainer()
    {
        return new FlowContainer();
    }
    
    public HFlowContainer HFlowContainer()
    {
        return new HFlowContainer();
    }
    
    public VFlowContainer VFlowContainer()
    {
        return new VFlowContainer();
    }
    
    public GraphElement GraphElement()
    {
        return new GraphElement();
    }
    
    public GridContainer GridContainer()
    {
        return new GridContainer();
    }
    
    public MarginContainer MarginContainer()
    {
        return new MarginContainer();
    }
    
    public PanelContainer PanelContainer()
    {
        return new PanelContainer();
    }
    
    public ScrollContainer ScrollContainer()
    {
        return new ScrollContainer();
    }
    
    public SplitContainer SplitContainer()
    {
        return new SplitContainer();
    }
    
    public HSplitContainer HSplitContainer()
    {
        return new HSplitContainer();
    }
    
    public VSplitContainer VSplitContainer()
    {
        return new VSplitContainer();
    }
    
    public SubViewportContainer SubViewportContainer()
    {
        return new SubViewportContainer();
    }
    
    public TabContainer TabContainer()
    {
        return new TabContainer();
    }
    
    public GraphEdit GraphEdit()
    {
        return new GraphEdit();
    }
    
    public ItemList ItemList()
    {
        return new ItemList();
    }
    
    public Label Label()
    {
        return new Label();
    }
    
    public LineEdit LineEdit()
    {
        return new LineEdit();
    }
    
    public MenuBar MenuBar()
    {
        return new MenuBar();
    }
    
    public NinePatchRect NinePatchRect()
    {
        return new NinePatchRect();
    }
    
    public Panel Panel()
    {
        return new Panel();
    }
    
    public ReferenceRect ReferenceRect()
    {
        return new ReferenceRect();
    }
    
    public RichTextLabel RichTextLabel()
    {
        return new RichTextLabel();
    }
    
    public Godot.Range Range()
    {
        return new Godot.Range();
    }
    
    public ProgressBar ProgressBar()
    {
        return new ProgressBar();
    }
    
    public HScrollBar HScrollBar()
    {
        return new HScrollBar();
    }
    
    public VScrollBar VScrollBar()
    {
        return new VScrollBar();
    }
    
    
    public HSlider HSlider()
    {
        return new HSlider();
    }
    
    public VSlider VSlider()
    {
        return new VSlider();
    }
    
    public SpinBox SpinBox()
    {
        return new SpinBox();
    }
    
    public TextureProgressBar TextureProgressBar()
    {
        return new TextureProgressBar();
    }
    
    public HSeparator HSeparator()
    {
        return new HSeparator();
    }
    
    public VSeparator VSeparator()
    {
        return new VSeparator();
    }
    
    public TabBar TabBar()
    {
        return new TabBar();
    }
    
    public TextureRect TextureRect()
    {
        return new TextureRect();
    }
    
    public Tree Tree()
    {
        return new Tree();
    }
    
    public VideoStreamPlayer VideoStreamPlayer()
    {
        return new VideoStreamPlayer();
    }

    public Node2D Node2D()
    {
        return new Node2D();
    }

    public AnimatedSprite2D AnimatedSprite2D()
    {
        return new AnimatedSprite2D();
    }

    public AudioListener2D AudioListener2D()
    {
        return new AudioListener2D();
    }

    public AudioStreamPlayer2D AudioStreamPlayer2D()
    {
        return new AudioStreamPlayer2D();
    }

    public BackBufferCopy BackBufferCopy()
    {
        return new BackBufferCopy();
    }

    public Bone2D Bone2D()
    {
        return new Bone2D();
    }

    public Camera2D Camera2D()
    {
        return new Camera2D();
    }

    public CanvasGroup CanvasGroup()
    {
        return new CanvasGroup();
    }

    public CanvasModulate CanvasModulate()
    {
        return new CanvasModulate();
    }

    public Area2D Area2D()
    {
        return new Area2D();
    }

    public CharacterBody2D CharacterBody2D()
    {
        return new CharacterBody2D();
    }

    public RigidBody2D RigidBody2D()
    {
        return new RigidBody2D();
    }

    public PhysicalBone2D PhysicalBone2D()
    {
        return new PhysicalBone2D();
    }

    public StaticBody2D StaticBody2D()
    {
        return new StaticBody2D();
    }

    public AnimatableBody2D AnimatableBody2D()
    {
        return new AnimatableBody2D();
    }

    public CollisionPolygon2D CollisionPolygon2D()
    {
        return new CollisionPolygon2D();
    }

    public CollisionShape2D CollisionShape2D()
    {
        return new CollisionShape2D();
    }

    public CpuParticles2D CpuParticles2D()
    {
        return new CpuParticles2D();
    }

    public GpuParticles2D GpuParticles2D()
    {
        return new GpuParticles2D();
    }

    public DampedSpringJoint2D DampedSpringJoint2D()
    {
        return new DampedSpringJoint2D();
    }

    public GrooveJoint2D GrooveJoint2D()
    {
        return new GrooveJoint2D();
    }

    public PinJoint2D PinJoint2D()
    {
        return new PinJoint2D();
    }

    public DirectionalLight2D DirectionalLight2D()
    {
        return new DirectionalLight2D();
    }

    public PointLight2D PointLight2D()
    {
        return new PointLight2D();
    }

    public LightOccluder2D LightOccluder2D()
    {
        return new LightOccluder2D();
    }

    public Line2D Line2D()
    {
        return new Line2D();
    }

    public Marker2D Marker2D()
    {
        return new Marker2D();
    }

    public MeshInstance2D MeshInstance2D()
    {
        return new MeshInstance2D();
    }

    public MultiMeshInstance2D MultiMeshInstance2D()
    {
        return new MultiMeshInstance2D();
    }

    public NavigationLink2D NavigationLink2D()
    {
        return new NavigationLink2D();
    }

    public NavigationObstacle2D NavigationObstacle2D()
    {
        return new NavigationObstacle2D();
    }

    public NavigationRegion2D NavigationRegion2D()
    {
        return new NavigationRegion2D();
    }

    public Parallax2D Parallax2D()
    {
        return new Parallax2D();
    }

    public ParallaxLayer ParallaxLayer()
    {
        return new ParallaxLayer();
    }

    public Path2D Path2D()
    {
        return new Path2D();
    }

    public PathFollow2D PathFollow2D()
    {
        return new PathFollow2D();
    }

    public Polygon2D Polygon2D()
    {
        return new Polygon2D();
    }

    public RayCast2D RayCast2D()
    {
        return new RayCast2D();
    }

    public RemoteTransform2D RemoteTransform2D()
    {
        return new RemoteTransform2D();
    }

    public ShapeCast2D ShapeCast2D()
    {
        return new ShapeCast2D();
    }

    public Skeleton2D Skeleton2D()
    {
        return new Skeleton2D();
    }

    public Sprite2D Sprite2D()
    {
        return new Sprite2D();
    }

    public TileMap TileMap()
    {
        return new TileMap();
    }

    public TileMapLayer TileMapLayer()
    {
        return new TileMapLayer();
    }

    public TouchScreenButton TouchScreenButton()
    {
        return new TouchScreenButton();
    }

    public VisibleOnScreenNotifier2D VisibleOnScreenNotifier2D()
    {
        return new VisibleOnScreenNotifier2D();
    }

    public VisibleOnScreenEnabler2D VisibleOnScreenEnabler2D()
    {
        return new VisibleOnScreenEnabler2D();
    }

    public Node3D Node3D()
    {
        return new Node3D();
    }

    public AudioListener3D AudioListener3D()
    {
        return new AudioListener3D();
    }

    public AudioStreamPlayer3D AudioStreamPlayer3D()
    {
        return new AudioStreamPlayer3D();
    }

    public BoneAttachment3D BoneAttachment3D()
    {
        return new BoneAttachment3D();
    }

    public Camera3D Camera3D()
    {
        return new Camera3D();
    }

    public XRCamera3D XRCamera3D()
    {
        return new XRCamera3D();
    }

    public Area3D Area3D()
    {
        return new Area3D();
    }

    public CharacterBody3D CharacterBody3D()
    {
        return new CharacterBody3D();
    }

    public PhysicalBone3D PhysicalBone3D()
    {
        return new PhysicalBone3D();
    }

    public RigidBody3D RigidBody3D()
    {
        return new RigidBody3D();
    }

    public VehicleBody3D VehicleBody3D()
    {
        return new VehicleBody3D();
    }

    public StaticBody3D StaticBody3D()
    {
        return new StaticBody3D();
    }

    public AnimatableBody3D AnimatableBody3D()
    {
        return new AnimatableBody3D();
    }

    public CollisionPolygon3D CollisionPolygon3D()
    {
        return new CollisionPolygon3D();
    }

    public CollisionShape3D CollisionShape3D()
    {
        return new CollisionShape3D();
    }

    public GridMap GridMap()
    {
        return new GridMap();
    }

    public ImporterMeshInstance3D ImporterMeshInstance3D()
    {
        return new ImporterMeshInstance3D();
    }

    public ConeTwistJoint3D ConeTwistJoint3D()
    {
        return new ConeTwistJoint3D();
    }

    public Generic6DofJoint3D Generic6DofJoint3D()
    {
        return new Generic6DofJoint3D();
    }

    public HingeJoint3D HingeJoint3D()
    {
        return new HingeJoint3D();
    }

    public PinJoint3D PinJoint3D()
    {
        return new PinJoint3D();
    }

    public SliderJoint3D SliderJoint3D()
    {
        return new SliderJoint3D();
    }

    public LightmapProbe LightmapProbe()
    {
        return new LightmapProbe();
    }
    public Marker3D Marker3D() {
        return new Marker3D();
    }

    public NavigationLink3D NavigationLink3D()
    {
        return new NavigationLink3D();
    }

    public NavigationObstacle3D NavigationObstacle3D()
    {
        return new NavigationObstacle3D();
    }

    public NavigationRegion3D NavigationRegion3D()
    {
        return new NavigationRegion3D();
    }

    public OpenXRCompositionLayerCylinder OpenXRCompositionLayerCylinder()
    {
        return new OpenXRCompositionLayerCylinder();
    }

    public OpenXRCompositionLayerEquirect OpenXRCompositionLayerEquirect()
    {
        return new OpenXRCompositionLayerEquirect();
    }

    public OpenXRCompositionLayerQuad OpenXRCompositionLayerQuad()
    {
        return new OpenXRCompositionLayerQuad();
    }

    public Path3D Path3D()
    {
        return new Path3D();
    }

    public PathFollow3D PathFollow3D()
    {
        return new PathFollow3D();
    }

    public RayCast3D RayCast3D()
    {
        return new RayCast3D();
    }

    public RemoteTransform3D RemoteTransform3D()
    {
        return new RemoteTransform3D();
    }

    public ShapeCast3D ShapeCast3D()
    {
        return new ShapeCast3D();
    }

    public Skeleton3D Skeleton3D()
    {
        return new Skeleton3D();
    }

    public SkeletonModifier3D SkeletonModifier3D()
    {
        return new SkeletonModifier3D();
    }

    public SpringArm3D SpringArm3D()
    {
        return new SpringArm3D();
    }

    public VehicleWheel3D VehicleWheel3D()
    {
        return new VehicleWheel3D();
    }

    public VisualInstance3D VisualInstance3D()
    {
        return new VisualInstance3D();
    }

    public Decal Decal()
    {
        return new Decal();
    }

    public FogVolume FogVolume()
    {
        return new FogVolume();
    }

    public GeometryInstance3D GeometryInstance3D()
    {
        return new GeometryInstance3D();
    }

    public CpuParticles3D CpuParticles3D()
    {
        return new CpuParticles3D();
    }

    public CsgCombiner3D CsgCombiner3D()
    {
        return new CsgCombiner3D();
    }

    public CsgBox3D CsgBox3D()
    {
        return new CsgBox3D();
    }

    public CsgCylinder3D CsgCylinder3D()
    {
        return new CsgCylinder3D();
    }

    public CsgMesh3D CsgMesh3D()
    {
        return new CsgMesh3D();
    }

    public CsgPolygon3D CsgPolygon3D()
    {
        return new CsgPolygon3D();
    }

    public CsgSphere3D CsgSphere3D()
    {
        return new CsgSphere3D();
    }

    public CsgTorus3D CsgTorus3D()
    {
        return new CsgTorus3D();
    }

    public GpuParticles3D GpuParticles3D()
    {
        return new GpuParticles3D();
    }

    public Label3D Label3D()
    {
        return new Label3D();
    }

    public MeshInstance3D MeshInstance3D()
    {
        return new MeshInstance3D();
    }

    public SoftBody3D SoftBody3D()
    {
        return new SoftBody3D();
    }

    public MultiMeshInstance3D MultiMeshInstance3D()
    {
        return new MultiMeshInstance3D();
    }

    public Sprite3D Sprite3D()
    {
        return new Sprite3D();
    }

    public AnimatedSprite3D AnimatedSprite3D()
    {
        return new AnimatedSprite3D();
    }

    public GpuParticlesAttractorBox3D GpuParticlesAttractorBox3D()
    {
        return new GpuParticlesAttractorBox3D();
    }

    public GpuParticlesAttractorSphere3D GpuParticlesAttractorSphere3D()
    {
        return new GpuParticlesAttractorSphere3D();
    }

    public GpuParticlesAttractorVectorField3D GpuParticlesAttractorVectorField3D()
    {
        return new GpuParticlesAttractorVectorField3D();
    }

    public GpuParticlesCollisionBox3D GpuParticlesCollisionBox3D()
    {
        return new GpuParticlesCollisionBox3D();
    }

    public GpuParticlesCollisionHeightField3D GpuParticlesCollisionHeightField3D()
    {
        return new GpuParticlesCollisionHeightField3D();
    }

    public GpuParticlesCollisionSdf3D GpuParticlesCollisionSdf3D()
    {
        return new GpuParticlesCollisionSdf3D();
    }

    public GpuParticlesCollisionSphere3D GpuParticlesCollisionSphere3D()
    {
        return new GpuParticlesCollisionSphere3D();
    }

    public DirectionalLight3D DirectionalLight3D()
    {
        return new DirectionalLight3D();
    }

    public OmniLight3D OmniLight3D()
    {
        return new OmniLight3D();
    }

    public SpotLight3D SpotLight3D()
    {
        return new SpotLight3D();
    }

    public LightmapGI LightmapGI()
    {
        return new LightmapGI();
    }

    public OccluderInstance3D OccluderInstance3D()
    {
        return new OccluderInstance3D();
    }

    public ReflectionProbe ReflectionProbe()
    {
        return new ReflectionProbe();
    }

    public VisibleOnScreenNotifier3D VisibleOnScreenNotifier3D()
    {
        return new VisibleOnScreenNotifier3D();
    }

    public VisibleOnScreenEnabler3D VisibleOnScreenEnabler3D()
    {
        return new VisibleOnScreenEnabler3D();
    }

    public VoxelGI VoxelGI()
    {
        return new VoxelGI();
    }

    public XRFaceModifier3D XRFaceModifier3D()
    {
        return new XRFaceModifier3D();
    }

    public XRNode3D XRNode3D()
    {
        return new XRNode3D();
    }

    public XRAnchor3D XRAnchor3D()
    {
        return new XRAnchor3D();
    }

    public XRController3D XRController3D()
    {
        return new XRController3D();
    }

    public XROrigin3D XROrigin3D()
    {
        return new XROrigin3D();
    }

}