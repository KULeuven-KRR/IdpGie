
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/IdpGieTest.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../bin/Debug/IdpGie.exe
BUILD_DIR = bin/Debug

IDPGIETEST_DLL_MDB_SOURCE=bin/Debug/IdpGieTest.dll.mdb
IDPGIETEST_DLL_MDB=$(BUILD_DIR)/IdpGieTest.dll.mdb
IDPGIE_EXE_SOURCE=../bin/Debug/IdpGie.exe
IDPGIE_EXE_MDB_SOURCE=../bin/Debug/IdpGie.exe.mdb
OPENTK_DLL_SOURCE=../libs/OpenTK.dll
OPENTK_DLL_CONFIG_SOURCE=../libs/OpenTK.dll.config
OPENTK_GLCONTROL_DLL_SOURCE=../libs/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=../libs/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL_SOURCE=../libs/NDesk.Options.dll
HTMLAGILITYPACK_DLL_SOURCE=../libs/HtmlAgilityPack.dll
GLSHARP_DLL_SOURCE=../glsharp/GLSharp/bin/Debug/GLSharp.dll
GLSHARP_DLL_MDB_SOURCE=../glsharp/GLSharp/bin/Debug/GLSharp.dll.mdb
GLSHARP_DLL_MDB=$(BUILD_DIR)/GLSharp.dll.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/IdpGieTest.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../bin/Release/IdpGie.exe
BUILD_DIR = bin/Release

IDPGIETEST_DLL_MDB=
IDPGIE_EXE_SOURCE=../bin/Debug/IdpGie.exe
IDPGIE_EXE_MDB_SOURCE=../bin/Debug/IdpGie.exe.mdb
OPENTK_DLL_SOURCE=../libs/OpenTK.dll
OPENTK_DLL_CONFIG_SOURCE=../libs/OpenTK.dll.config
OPENTK_GLCONTROL_DLL_SOURCE=../libs/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL_SOURCE=../libs/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL_SOURCE=../libs/NDesk.Options.dll
HTMLAGILITYPACK_DLL_SOURCE=../libs/HtmlAgilityPack.dll
GLSHARP_DLL_SOURCE=../glsharp/GLSharp/bin/Release/GLSharp.dll
GLSHARP_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(IDPGIETEST_DLL_MDB) \
	$(IDPGIE_EXE) \
	$(IDPGIE_EXE_MDB) \
	$(OPENTK_DLL) \
	$(OPENTK_DLL_CONFIG) \
	$(OPENTK_GLCONTROL_DLL) \
	$(QUT_SHIFTREDUCEPARSER_DLL) \
	$(NDESK_OPTIONS_DLL) \
	$(HTMLAGILITYPACK_DLL) \
	$(GLSHARP_DLL) \
	$(GLSHARP_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(IDPGIETEST_PC)  


RESGEN=resgen2

IDPGIE_EXE = $(BUILD_DIR)/IdpGie.exe
IDPGIE_EXE_MDB = $(BUILD_DIR)/IdpGie.exe.mdb
OPENTK_DLL = $(BUILD_DIR)/OpenTK.dll
OPENTK_DLL_CONFIG = $(BUILD_DIR)/OpenTK.dll.config
OPENTK_GLCONTROL_DLL = $(BUILD_DIR)/OpenTK.GLControl.dll
QUT_SHIFTREDUCEPARSER_DLL = $(BUILD_DIR)/QUT.ShiftReduceParser.dll
NDESK_OPTIONS_DLL = $(BUILD_DIR)/NDesk.Options.dll
HTMLAGILITYPACK_DLL = $(BUILD_DIR)/HtmlAgilityPack.dll
GLSHARP_DLL = $(BUILD_DIR)/GLSharp.dll
IDPGIETEST_PC = $(BUILD_DIR)/idpgietest.pc

FILES = \
	IFunctionInstanceTest.cs \
	DocumentSizeTest.cs \
	Interaction/Idp/IdpSessionTest.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Interaction \
	Interaction/Idp \
	idpgietest.pc.in 

REFERENCES =  \
	System \
	-pkg:nunit

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,IDPGIE_EXE))
$(eval $(call emit-deploy-target,IDPGIE_EXE_MDB))
$(eval $(call emit-deploy-target,OPENTK_DLL))
$(eval $(call emit-deploy-target,OPENTK_DLL_CONFIG))
$(eval $(call emit-deploy-target,OPENTK_GLCONTROL_DLL))
$(eval $(call emit-deploy-target,QUT_SHIFTREDUCEPARSER_DLL))
$(eval $(call emit-deploy-target,NDESK_OPTIONS_DLL))
$(eval $(call emit-deploy-target,HTMLAGILITYPACK_DLL))
$(eval $(call emit-deploy-target,GLSHARP_DLL))
$(eval $(call emit-deploy-target,GLSHARP_DLL_MDB))
$(eval $(call emit-deploy-wrapper,IDPGIETEST_PC,idpgietest.pc))


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
	$(call cp,$(IDPGIETEST_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(IDPGIE_EXE),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(IDPGIE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_DLL_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(OPENTK_GLCONTROL_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(NDESK_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(HTMLAGILITYPACK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GLSHARP_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(GLSHARP_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(IDPGIETEST_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDPGIETEST_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDPGIE_EXE),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDPGIE_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_DLL_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(OPENTK_GLCONTROL_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(QUT_SHIFTREDUCEPARSER_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(NDESK_OPTIONS_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(HTMLAGILITYPACK_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GLSHARP_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(GLSHARP_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(IDPGIETEST_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
