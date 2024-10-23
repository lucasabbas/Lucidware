using Godot;
using MoonSharp.Interpreter;
using Timer = Godot.Timer;

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

}