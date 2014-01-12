

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=.

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;" "-keyfile:../../../keypair.snk"
ASSEMBLY = bin/Debug/IdpGie.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

IDPGIE_EXE_MDB_SOURCE=bin/Debug/IdpGie.exe.mdb
IDPGIE_EXE_MDB=$(BUILD_DIR)/IdpGie.exe.mdb
OPENTK_DLL_SOURCE=libs/OpenTK.dll
OPENTK_DLL_CONFIG_SOURCE=libs/OpenTK.dll.config
OPENTK_GLCONTROL_DLL_SOURCE=libs/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=libs/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL_SOURCE=libs/NDesk.Options.dll

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-keyfile:../../../keypair.snk"
ASSEMBLY = bin/Release/IdpGie.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

IDPGIE_EXE_MDB=
OPENTK_DLL_SOURCE=libs/OpenTK.dll
OPENTK_DLL_CONFIG_SOURCE=libs/OpenTK.dll.config
OPENTK_GLCONTROL_DLL_SOURCE=libs/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=libs/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL_SOURCE=libs/NDesk.Options.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(IDPGIE_EXE_MDB) \
	$(OPENTK_DLL) \
	$(OPENTK_DLL_CONFIG) \
	$(OPENTK_GLCONTROL_DLL) \
	$(QUT_SHIFTREDUCEPARSER_DLL) \
	$(NDESK_OPTIONS_DLL)  

BINARIES = \
	$(IDP_GIE)  


RESGEN=resgen2

OPENTK_DLL = $(BUILD_DIR)/OpenTK.dll
OPENTK_DLL_CONFIG = $(BUILD_DIR)/OpenTK.dll.config
OPENTK_GLCONTROL_DLL = $(BUILD_DIR)/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL = $(BUILD_DIR)/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL = $(BUILD_DIR)/NDesk.Options.dll
IDP_GIE = $(BUILD_DIR)/idp-gie

FILES = \
	Point.cs \
	IName.cs \
	NameBase.cs \
	GtkTimeWidget.cs \
	BlueprintMediabar.cs \
	MediaMode.cs \
	BlueprintStyle.cs \
	TopWindow.cs \
	MediaButtons.cs \
	Lexer.cs \
	LexSpan.cs \
	FunctionInstance.cs \
	Predicate.cs \
	Function.cs \
	Parser.cs \
	HeadTail.cs \
	Term.cs \
	Atom.cs \
	DrawTheory.cs \
	TermType.cs \
	ArrayFunction.cs \
	ArrayTailFunction.cs \
	MathExtra.cs \
	ITimesensitive.cs \
	TimeSensitiveBase.cs \
	TypedPredicate.cs \
	IValidate.cs \
	TypedMethodPredicate.cs \
	LocalInputContext.cs \
	GlobalInputContext.cs \
	IInputContext.cs \
	TermHeader.cs \
	AssemblyInfo.cs \
	ITermHeader.cs \
	ArrayHeadTailFunctionInstance.cs \
	IArrayFunctionInstance.cs \
	EnumerableUtils.cs \
	NamedObject.cs \
	DrawTheoryMode.cs \
	IPriority.cs \
	PriorityComparator.cs \
	ITerm.cs \
	IAtom.cs \
	IFunctionInstance.cs \
	IFunction.cs \
	IPredicate.cs \
	NamedFunctionInstance.cs \
	ITheoryItem.cs \
	IPositiveClause.cs \
	PositiveClause.cs \
	NamedAttributeBase.cs \
	Interval.cs \
	TypeSystem.cs \
	IZIndex.cs \
	StructureFunctionInstance.cs \
	StructureFunction.cs \
	IArity.cs \
	NameArityPriorityBase.cs \
	INameArity.cs \
	NameArityBase.cs \
	EnhancedTermCollection.cs \
	CairoFrameWidget.cs \
	ZIndexComparator.cs \
	IMediaObject.cs \
	CairoMediaWidget.cs \
	OpenGLFrameWidget.cs \
	IInterpolatable.cs \
	TimeSensitiveComparer.cs \
	BlueprintTabControl.cs \
	CairoUtils.cs \
	ShapePolygon.cs \
	ShapeEllipse.cs \
	ShapeIrregularPolygonObject.cs \
	ShapeRegularPolygonObject.cs \
	ShapeGraph.cs \
	GraphModifier.cs \
	AddNodeGraphModifier.cs \
	NodeGraphModifier.cs \
	ITermName.cs \
	ShapeImage.cs \
	CairoImageStore.cs \
	IFlyWeight.cs \
	HardFlyweight.cs \
	WeakFlyweight.cs \
	ProgramManager.cs \
	OutputDevice.cs \
	OutputCairoDevice.cs \
	OutputOpenGLDevice.cs \
	OutputPrintDevice.cs \
	OutputLaTeXDevice.cs \
	PaintMapping.cs \
	EventArgs.cs \
	ITagable.cs \
	Box2d.cs \
	IGeometry2d.cs \
	Shape.cs \
	IShape.cs \
	IShapeTransformable.cs \
	DrawMethodAttribute.cs \
	MapperAttribute.cs \
	ShapeState.cs \
	NamedObjectAttribute.cs \
	MethodBaseAttribute.cs \
	NamedObjectEnumAttribute.cs \
	HookMethodAttribute.cs \
	ShapeStateModifier.cs \
	IShapeStateModifier.cs \
	TheoryAlteringMethodAttribute.cs \
	FunctionFloatInstance.cs \
	FunctionStructureAttribute.cs \
	FunctionStructureConstructorAttribute.cs \
	FunctionIntegerInstance.cs \
	FunctionStringInstance.cs \
	ColorStructure.cs \
	FunctionVirtualInstance.cs \
	ITimeSensitiveFastReversible.cs \
	TimeSensitiveReversibleBase.cs \
	TimeSensitiveFastReversibleBase.cs \
	ITimeSensitiveReversible.cs \
	CollectionUtils.cs \
	gtk-gui/generated.cs \
	gtk-gui/IdpGie.TopWindow.cs \
	AddTheoryAlteringMethod.cs \
	ITheoryAlteringMethod.cs \
	IAlteringStreamMethod.cs \
	AlteringStreamMethodUtils.cs \
	RemoveTheoryAlteringMethod.cs \
	TermTheoryAlteringMethod.cs \
	IHook.cs \
	HookType.cs \
	Keys.cs \
	KeyHook.cs \
	IdpGieException.cs \
	ShapeSvgPath.cs \
	Scanner.cs \
	PushbackTextReader.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic 

EXTRAS = \
	lex.ll \
	parse.yy \
	../../../keypair.snk \
	idp-gie.in 

REFERENCES =  \
	-pkg:gtk-sharp-2.0 \
	Mono.Cairo \
	System \
	System.Core \
	System.Data \
	System.Data.Linq \
	Mono.Posix \
	-pkg:glib-sharp-2.0

DLL_REFERENCES =  \
	libs/OpenTK.dll \
	libs/OpenTK.GLControl.dll \
	libs/QUT.ShiftReduceParser.dll \
	libs/NDesk.Options.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,OPENTK_DLL))
$(eval $(call emit-deploy-target,OPENTK_DLL_CONFIG))
$(eval $(call emit-deploy-target,OPENTK_GLCONTROL_DLL))
$(eval $(call emit-deploy-target,QUT_SHIFTREDUCEPARSER_DLL))
$(eval $(call emit-deploy-target,NDESK_OPTIONS_DLL))
$(eval $(call emit-deploy-wrapper,IDP_GIE,idp-gie,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

# Targets for Custom commands
DEBUG|X86_BeforeBuild:
	(cd ${SolutionDir} && bash buildparser.sh)


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(IDPGIE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_DLL_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_GLCONTROL_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(NDESK_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(IDP_GIE),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDPGIE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_DLL_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_GLCONTROL_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(NDESK_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDP_GIE),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
