

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
PROJECT_REFERENCES =  \
	glsharp/GLSharp/bin/Debug/GLSharp.dll
BUILD_DIR = bin/Debug

IDPGIE_EXE_MDB_SOURCE=bin/Debug/IdpGie.exe.mdb
IDPGIE_EXE_MDB=$(BUILD_DIR)/IdpGie.exe.mdb
OPENTK_DLL_SOURCE=libs/OpenTK.dll
OPENTK_DLL_CONFIG_SOURCE=libs/OpenTK.dll.config
OPENTK_GLCONTROL_DLL_SOURCE=libs/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=libs/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL_SOURCE=libs/NDesk.Options.dll
HTMLAGILITYPACK_DLL_SOURCE=libs/HtmlAgilityPack.dll
GLSHARP_DLL_SOURCE=glsharp/GLSharp/bin/Debug/GLSharp.dll
GLSHARP_DLL_MDB_SOURCE=glsharp/GLSharp/bin/Debug/GLSharp.dll.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-keyfile:../../../keypair.snk"
ASSEMBLY = bin/Release/IdpGie.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	glsharp/GLSharp/bin/Release/GLSharp.dll
BUILD_DIR = bin/Release

IDPGIE_EXE_MDB=
OPENTK_DLL_SOURCE=libs/OpenTK.dll
OPENTK_DLL_CONFIG_SOURCE=libs/OpenTK.dll.config
OPENTK_GLCONTROL_DLL_SOURCE=libs/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=libs/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL_SOURCE=libs/NDesk.Options.dll
HTMLAGILITYPACK_DLL_SOURCE=libs/HtmlAgilityPack.dll
GLSHARP_DLL_SOURCE=glsharp/GLSharp/bin/Debug/GLSharp.dll
GLSHARP_DLL_MDB_SOURCE=glsharp/GLSharp/bin/Debug/GLSharp.dll.mdb

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(IDPGIE_EXE_MDB) \
	$(OPENTK_DLL) \
	$(OPENTK_DLL_CONFIG) \
	$(OPENTK_GLCONTROL_DLL) \
	$(QUT_SHIFTREDUCEPARSER_DLL) \
	$(NDESK_OPTIONS_DLL) \
	$(HTMLAGILITYPACK_DLL) \
	$(GLSHARP_DLL) \
	$(GLSHARP_DLL_MDB)  

BINARIES = \
	$(IDP_GIE)  


RESGEN=resgen2

OPENTK_DLL = $(BUILD_DIR)/OpenTK.dll
OPENTK_DLL_CONFIG = $(BUILD_DIR)/OpenTK.dll.config
OPENTK_GLCONTROL_DLL = $(BUILD_DIR)/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL = $(BUILD_DIR)/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL = $(BUILD_DIR)/NDesk.Options.dll
HTMLAGILITYPACK_DLL = $(BUILD_DIR)/HtmlAgilityPack.dll
GLSHARP_DLL = $(BUILD_DIR)/GLSharp.dll
GLSHARP_DLL_MDB = $(BUILD_DIR)/GLSharp.dll.mdb
IDP_GIE = $(BUILD_DIR)/idp-gie

FILES = \
	AssemblyInfo.cs \
	gtk-gui/generated.cs \
	gtk-gui/IdpGie.UserInterface.TopWindow.cs \
	Abstract/CloneableBase.cs \
	Abstract/EventArgs.cs \
	Abstract/HardFlyweight.cs \
	Abstract/IAlterable.cs \
	Abstract/ICloneable.cs \
	Abstract/IDescription.cs \
	Abstract/IInterpolatable.cs \
	Abstract/IName.cs \
	Abstract/INameArity.cs \
	Abstract/INameDescription.cs \
	Abstract/IPriority.cs \
	Abstract/IReloadable.cs \
	Abstract/ITagable.cs \
	Abstract/ITimeSensitiveFastReversible.cs \
	Abstract/ITimeSensitiveReversible.cs \
	Abstract/ITimesensitive.cs \
	Abstract/IValidate.cs \
	Abstract/IZIndex.cs \
	Abstract/NameArityBase.cs \
	Abstract/NameArityPriorityBase.cs \
	Abstract/NameBase.cs \
	Abstract/NamedAttributeBase.cs \
	Abstract/NamedDescribedAttributeBase.cs \
	Abstract/PriorityComparator.cs \
	Abstract/TimeSensitiveBase.cs \
	Abstract/TimeSensitiveComparer.cs \
	Abstract/TimeSensitiveFastReversibleBase.cs \
	Abstract/TimeSensitiveReversibleBase.cs \
	Abstract/WeakFlyweight.cs \
	Abstract/ZIndexComparator.cs \
	Core/DrawTheory.cs \
	Core/IDrawTheorySensitive.cs \
	Core/ProcessSession.cs \
	Core/ProgramManager.cs \
	Engines/CairoEngine.cs \
	Engines/IRenderEngine.cs \
	Geometry/Box2d.cs \
	Geometry/CanvasSize.cs \
	Geometry/ICanvasSize.cs \
	Geometry/StripCanvasSize.cs \
	Geometry/StripGeometry.cs \
	Interaction/AlterableContentChangeableStreamBase.cs \
	Interaction/ContentChangeableStreamBase.cs \
	Interaction/IAlterableReloadableChangeableStream.cs \
	Logic/ArrayFunction.cs \
	Logic/ArrayHeadTailFunctionInstance.cs \
	Logic/ArrayTailFunction.cs \
	Logic/Atom.cs \
	Logic/Body.cs \
	Logic/Function.cs \
	Logic/FunctionFloatInstance.cs \
	Logic/FunctionInstance.cs \
	Logic/FunctionIntegerInstance.cs \
	Logic/FunctionStringInstance.cs \
	Logic/FunctionStructureAttribute.cs \
	Logic/FunctionStructureConstructorAttribute.cs \
	Logic/FunctionVirtualInstance.cs \
	Logic/GlobalInputContext.cs \
	Logic/HookBase.cs \
	Logic/HookKey.cs \
	Logic/IArrayFunctionInstance.cs \
	Logic/IAtom.cs \
	Logic/IEnhancedTermCollection.cs \
	Logic/IFunction.cs \
	Logic/IFunctionInstance.cs \
	Logic/IHook.cs \
	Logic/IInputContext.cs \
	Logic/IPositiveClause.cs \
	Logic/IPredicate.cs \
	Logic/ITerm.cs \
	Logic/ITermHeader.cs \
	Logic/ITermName.cs \
	Logic/ITheoryItem.cs \
	Logic/KeyValueEntry.cs \
	Logic/LocalInputContext.cs \
	Logic/NamedFunctionDtime.cs \
	Logic/NamedFunctionInstance.cs \
	Logic/NamedFunctionItime.cs \
	Logic/NamedObject.cs \
	Logic/NamedObjectAttribute.cs \
	Logic/NamedObjectEnumAttribute.cs \
	Logic/PositiveClause.cs \
	Logic/Predicate.cs \
	Logic/StructureFunction.cs \
	Logic/StructureFunctionInstance.cs \
	Logic/Term.cs \
	Logic/TermHeader.cs \
	Logic/TermType.cs \
	Logic/TypeSystem.cs \
	Logic/TypedClauseMethodPredicate.cs \
	Logic/TypedMethodPredicate.cs \
	Logic/TypedPredicate.cs \
	Mappers/AlterMethodAttribute.cs \
	Mappers/AlteringMapping.cs \
	Mappers/HookMapping.cs \
	Mappers/HookMethodAttribute.cs \
	Mappers/HookMethodPredicate.cs \
	Mappers/MapperAttribute.cs \
	Mappers/MethodBaseAttribute.cs \
	Mappers/PaintMapping.cs \
	Mappers/PaintMethodAttribute.cs \
	OutputDevices/IHttpGieServer.cs \
	OutputDevices/IOutputDevice.cs \
	OutputDevices/OutputCairoDevice.cs \
	OutputDevices/OutputDevice.cs \
	OutputDevices/OutputDeviceAttribute.cs \
	OutputDevices/OutputHttpServerDevice.cs \
	OutputDevices/OutputLaTeXDevice.cs \
	OutputDevices/OutputOpenGLDevice.cs \
	OutputDevices/OutputPdfDevice.cs \
	OutputDevices/OutputPdfStripDevice.cs \
	OutputDevices/OutputPrintDevice.cs \
	OutputDevices/OutputWindowDevice.cs \
	Shapes/IShape.cs \
	Shapes/IShapeHierarchical.cs \
	Shapes/IShapeModifiableHierarchical.cs \
	Shapes/Shape.cs \
	Shapes/ShapeActiveHtml.cs \
	Shapes/ShapeBalloon.cs \
	Shapes/ShapeEllipse.cs \
	Shapes/ShapeGraph.cs \
	Shapes/ShapeHierarchical.cs \
	Shapes/ShapeImage.cs \
	Shapes/ShapeIrregularPolygonObject.cs \
	Shapes/ShapePage.cs \
	Shapes/ShapePolygon.cs \
	Shapes/ShapeRegularPolygonObject.cs \
	Shapes/ShapeState.cs \
	Shapes/ShapeStateAttribute.cs \
	Shapes/ShapeSvgPath.cs \
	Shapes/Modifiers/AddNodeGraphModifier.cs \
	Shapes/Modifiers/GraphModifier.cs \
	Shapes/Modifiers/IShapeStateModifier.cs \
	Shapes/Modifiers/IShapeTransformable.cs \
	Shapes/Modifiers/NodeGraphModifier.cs \
	Shapes/Modifiers/ShapeStateModifier.cs \
	UserInterface/BlueprintMediabar.cs \
	UserInterface/BlueprintStyle.cs \
	UserInterface/BlueprintTabControl.cs \
	UserInterface/CairoFrameWidget.cs \
	UserInterface/CairoImageStore.cs \
	UserInterface/CairoMediaWidget.cs \
	UserInterface/CairoUtils.cs \
	UserInterface/ColorStructure.cs \
	UserInterface/GlFrameWidget.cs \
	UserInterface/GtkTimeWidget.cs \
	UserInterface/IMediaObject.cs \
	UserInterface/MediaButtons.cs \
	UserInterface/MediaMode.cs \
	UserInterface/TopWindow.cs \
	Utils/CollectionUtils.cs \
	Utils/DictionaryUtils.cs \
	Utils/EnumerableUtils.cs \
	Utils/HeadTail.cs \
	Utils/IdpGieException.cs \
	Utils/MathExtra.cs \
	Utils/ReadonlyCollection.cs \
	Utils/RegexDevelopment.cs \
	Utils/StringUtils.cs \
	Abstract/IArity.cs \
	Abstract/IContentChangeableStream.cs \
	Abstract/IFlyweight.cs \
	Shapes/ShapeModifiableHierarchical.cs \
	Shapes/IShapeState.cs \
	Abstract/IVisible.cs \
	Parser/LexSpan.cs \
	Parser/Lexer.cs \
	Parser/Parser.cs \
	Abstract/NamespaceDoc.cs \
	Core/NamespaceDoc.cs \
	Engines/NamespaceDoc.cs \
	Geometry/NamespaceDoc.cs \
	Interaction/NamespaceDoc.cs \
	Logic/NamespaceDoc.cs \
	Mappers/NamespaceDoc.cs \
	OutputDevices/NamespaceDoc.cs \
	Parser/NamespaceDoc.cs \
	Shapes/NamespaceDoc.cs \
	Shapes/Modifiers/NamespaceDoc.cs \
	UserInterface/NamespaceDoc.cs \
	Utils/NamespaceDoc.cs \
	Abstract/ITitle.cs \
	Engines/IEngine.cs \
	Engines/Engine.cs \
	Abstract/IInterval.cs \
	Abstract/DoubleInterval.cs \
	Core/IDrawTheory.cs \
	Core/IProcessSession.cs \
	Core/IProgramManager.cs \
	Abstract/IClearable.cs \
	Abstract/INameSet.cs \
	Abstract/IWriteable.cs \
	Abstract/WriteableExtensions.cs \
	Abstract/ITimeSensitiveSet.cs \
	Abstract/RuntimeFlagAttribute.cs \
	Engines/HttpEngine.cs \
	Engines/IWebEngine.cs \
	Geometry/IGeometry2dSpace.cs \
	Geometry/IBox2d.cs \
	Geometry/IStripGeometry.cs \
	Geometry/Point3.cs \
	Geometry/IPoint3.cs \
	Abstract/IHref.cs \
	Abstract/INameHref.cs \
	Abstract/NameHrefBase.cs \
	Abstract/IRuntimeFlagAttribute.cs \
	Abstract/ICompact.cs \
	Engines/ICairoContextSensitive.cs \
	Engines/ICairoEngine.cs \
	Core/DrawTheorySensitiveBase.cs \
	Geometry/IStripCanvasSize.cs \
	Shapes/Web/IWebShape.cs \
	Shapes/Web/WebPredicateTable.cs \
	Shapes/Web/WebShapeAttribute.cs \
	Shapes/Pages/DefaultQueryWebPage.cs \
	Shapes/Pages/FavIcon.cs \
	Shapes/Pages/IFavIcon.cs \
	Shapes/Pages/INavbar.cs \
	Shapes/Pages/IQueryWebPage.cs \
	Shapes/Pages/IWebPage.cs \
	Shapes/Pages/Navbar.cs \
	Shapes/Pages/WebPage.cs \
	Shapes/Pages/IWebPagePiece.cs \
	Shapes/Pages/DefaultWebPagePiece.cs \
	Shapes/Pages/WebPagePieceBase.cs \
	Shapes/Pages/HtmlTextWebPagePiece.cs \
	Shapes/Pages/HtmlElementPagePiece.cs \
	Shapes/Web/WebShapeBase.cs \
	Shapes/Web/WebPredicateTableColumn.cs \
	Abstract/IIndex.cs \
	Abstract/INameIndex.cs \
	Abstract/NameIndexBase.cs \
	Shapes/Pages/IQueryLandingWebPagePiece.cs \
	Shapes/Pages/QueryLandingWebPagePiece.cs \
	Abstract/IId.cs \
	Shapes/Web/IQueryWebPageShape.cs \
	Shapes/Web/QueryWebPageShapeBase.cs \
	Shapes/Pages/QueryWebPageBase.cs \
	Abstract/IdDispatcher.cs \
	Abstract/IPostDeserialize.cs \
	Abstract/ITable.cs \
	Interaction/ClingoSession.cs \
	Abstract/ICleanable.cs \
	Interaction/IProcessOutput.cs \
	Interaction/Idp/IIdentifier.cs \
	Interaction/Idp/IIdpInference.cs \
	Interaction/Idp/IIdpSession.cs \
	Interaction/Idp/IPredicateInterpretation.cs \
	Interaction/Idp/IPredicateTable.cs \
	Interaction/Idp/IStructure.cs \
	Interaction/Idp/ITheory.cs \
	Interaction/Idp/ITuple.cs \
	Interaction/Idp/IVocabulary.cs \
	Interaction/Idp/IVocabularyPredicate.cs \
	Interaction/Idp/IVocabularySensitive.cs \
	Interaction/Idp/PredicateTable.cs \
	Interaction/Idp/Tuple.cs \
	Interaction/Idp/Vocabulary.cs \
	Interaction/Idp/Identifier.cs \
	Interaction/Idp/IdpSession.cs \
	Interaction/Idp/IdpInteraction.cs \
	Interaction/Idp/IdpInteractiveStream.cs \
	Interaction/Idp/IIdpIdentifier.cs \
	Interaction/Idp/IdpIdentifier.cs \
	Interaction/Idp/VocabularyPredicate.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic \
	resources/favicon.ico,IdpGie.resources.favicon.ico 

EXTRAS = \
	lex.ll \
	parse.yy \
	Abstract \
	Core \
	Engines \
	Geometry \
	Interaction \
	Logic \
	Mappers \
	OutputDevices \
	Shapes \
	UserInterface \
	Utils \
	Parser \
	resources \
	Shapes/Web \
	Shapes/Pages \
	Interaction/Idp \
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
	-pkg:glib-sharp-2.0 \
	System.Xml \
	System.Web

DLL_REFERENCES =  \
	libs/OpenTK.dll \
	libs/OpenTK.GLControl.dll \
	libs/QUT.ShiftReduceParser.dll \
	libs/NDesk.Options.dll \
	libs/HtmlAgilityPack.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,OPENTK_DLL))
$(eval $(call emit-deploy-target,OPENTK_DLL_CONFIG))
$(eval $(call emit-deploy-target,OPENTK_GLCONTROL_DLL))
$(eval $(call emit-deploy-target,QUT_SHIFTREDUCEPARSER_DLL))
$(eval $(call emit-deploy-target,NDESK_OPTIONS_DLL))
$(eval $(call emit-deploy-target,HTMLAGILITYPACK_DLL))
$(eval $(call emit-deploy-target,GLSHARP_DLL))
$(eval $(call emit-deploy-target,GLSHARP_DLL_MDB))
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
	$(call cp,$(HTMLAGILITYPACK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GLSHARP_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GLSHARP_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
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
	$(call rm,$(HTMLAGILITYPACK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GLSHARP_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GLSHARP_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDP_GIE),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
