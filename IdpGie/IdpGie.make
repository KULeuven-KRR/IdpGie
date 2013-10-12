

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=.

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
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

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
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

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(IDPGIE_EXE_MDB) \
	$(OPENTK_DLL) \
	$(OPENTK_DLL_CONFIG) \
	$(OPENTK_GLCONTROL_DLL) \
	$(QUT_SHIFTREDUCEPARSER_DLL)  

BINARIES = \
	$(IDP_GIE)  


RESGEN=resgen2

OPENTK_DLL = $(BUILD_DIR)/OpenTK.dll
OPENTK_DLL_CONFIG = $(BUILD_DIR)/OpenTK.dll.config
OPENTK_GLCONTROL_DLL = $(BUILD_DIR)/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL = $(BUILD_DIR)/QUT.ShiftReduceParser.dll
IDP_GIE = $(BUILD_DIR)/idp-gie

FILES = \
	IdpdMethodAttribute.cs \
	IdpCairoMapping.cs \
	Point.cs \
	IdpdStructureAttribute.cs \
	IName.cs \
	NameBase.cs \
	GtkTimeWidget.cs \
	CairoWidget.cs \
	IdpdObject.cs \
	BlueprintMediabar.cs \
	MediaMode.cs \
	BlueprintStyle.cs \
	gtk-gui/generated.cs \
	TopWindow.cs \
	gtk-gui/IdpGie.TopWindow.cs \
	MediaButtons.cs \
	IdpdPolygonObject.cs \
	IdpEllipseObject.cs \
	IdpObjectModificationType.cs \
	IdpdObjectTimeState.cs \
	IZIndix.cs \
	IdpdOutputDevice.cs \
	IdpdCairoOutputDevice.cs \
	IdpdLaTeXOutputDevice.cs \
	OpenGLIdpOutputDevice.cs \
	IdpdPrintOutputDevice.cs \
	Lexer.cs \
	LexSpan.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic 

EXTRAS = \
	lex.ll \
	parse.yy \
	idp-gie.in 

REFERENCES =  \
	-pkg:gtk-sharp-2.0 \
	Mono.Cairo \
	System \
	System.Core \
	System.Data \
	System.Data.Linq \
	Mono.Posix

DLL_REFERENCES =  \
	libs/OpenTK.dll \
	libs/OpenTK.GLControl.dll \
	libs/QUT.ShiftReduceParser.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

#Targets
all-local: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES)  $(top_srcdir)/config.make



$(eval $(call emit-deploy-target,OPENTK_DLL))
$(eval $(call emit-deploy-target,OPENTK_DLL_CONFIG))
$(eval $(call emit-deploy-target,OPENTK_GLCONTROL_DLL))
$(eval $(call emit-deploy-target,QUT_SHIFTREDUCEPARSER_DLL))
$(eval $(call emit-deploy-wrapper,IDP_GIE,idp-gie,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


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
	$(call rm,$(IDP_GIE),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)
