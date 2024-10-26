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
        if (LuaEnviroment.Sandboxed == false)
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

        foreach (var type in GetTypesInheritedFrom(typeof(Node)))
        {
            if (!IsBlackListedType(type) || LuaEnviroment.Sandboxed == false)
            {
                UserData.RegisterType(type);
                GdCoreNamespace[type.Name] = type;
            }
        }
        
        foreach (var type in GetTypesInheritedFrom(typeof(RefCounted)))
        {
            if (!IsBlackListedType(type) || LuaEnviroment.Sandboxed == false)
            {
                UserData.RegisterType(type);
                GdCoreNamespace[type.Name] = type;
            }
        }
        
        Type[] enumTypes = GetEnumTypesFromNamespace("Godot");
        foreach (Type type in enumTypes)
        {
            // hack fix to stop the .NET debugger from bitching.
            bool isNested = type.IsNested;
                        
            if (!isNested)
            {
                UserData.RegisterType(type);
                GdCoreNamespace[type.Name] = type;
            }
        }
        
        
    }
    
    public Type[] GetTypesInheritedFrom(Type baseType)
    {
        Assembly assembly = baseType.Assembly;
        Type[] types = assembly.GetTypes();
        Type[] inheritedTypes = types.Where(t => t.IsSubclassOf(baseType)).ToArray();
        return inheritedTypes;
    }
    
    public Type[] GetEnumTypesFromAssembly(Assembly assembly)
    {
        List<Type> types = new List<Type>();
        foreach (var t in assembly.GetTypes())
        {
            if (t.IsEnum)
            {
                types.Add(t);
            }
        }
        return types.ToArray();
    }
    
    public static Type[] GetEnumTypesFromNamespace(string @namespace)
    {
        List<Type> types = new List<Type>();
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in asm.GetTypes())
            {
                if (type.Namespace == @namespace && type.IsEnum)
                {
                    types.Add(type);
                }
            }
        }

        return types.ToArray();
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
            typeof(ENetConnection)
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