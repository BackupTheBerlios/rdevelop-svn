# Makefile

ADDIN = RDevelop.RBinding

SRC_DIR   = Sources
BUILD_DIR = Build
TMP_DIR   = /tmp/$(ADDIN)

ADDIN_XML = $(ADDIN).addin.xml
ASSEMBLY = $(ADDIN).dll
SOURCES = $(wildcard $(SRC_DIR)/*.cs)

REFERENCES =\
 System.Xml\
 MonoDevelop.Core\
 MonoDevelop.Projects

RESOURCES = $(wildcard Sources/Templates/*.xml)

CS_PATH =\
 /usr/lib/mono/2.0/\
 /usr/lib/monodevelop/bin/\
 /usr/lib/monodevelop/AddIns/\
 /usr/lib/mono/gtk-sharp-2.0/

CSC = gmcs

CSC_FLAGS = -debug
CSC_DLL_FLAGS = $(CSC_FLAGS) $(CS_PATH:%=-lib:%) $(REFERENCES:%=-r:%) -target:library $(RESOURCES:%=-resource:%)

REMOTE_REP = shell.berlios.de:/home/groups/rdevelop/htdocs/add-ins

RSYNC = rsync
RSYNC_FLAGS = -aze ssh

all: build

build: $(BUILD_DIR)/$(ASSEMBLY)

$(BUILD_DIR)/$(ASSEMBLY): $(SOURCES) $(RESOURCES)
	install -d $(BUILD_DIR)
	$(CSC) $(CSC_DLL_FLAGS) -out:$@ $(SOURCES)

package:
	install -d $(TMP_DIR)
	cp -fR $(BUILD_DIR)/$(ASSEMBLY) $(TMP_DIR)
	cp -f $(ADDIN_XML) $(TMP_DIR)/$(ADDIN_XML)
	mdtool setup pack $(TMP_DIR)/$(ADDIN_XML) -d:$(BUILD_DIR)
	rm -fR $(TMP_DIR)

upload:
	install -d $(TMP_DIR)
	$(RSYNC) $(RSYNC_FLAGS) $(REMOTE_REP)/ $(TMP_DIR)/
	cp -f $(BUILD_DIR)/*.mpack $(TMP_DIR)
	mdtool setup rep-build $(TMP_DIR)
	$(RSYNC) $(RSYNC_FLAGS) --delete --force $(TMP_DIR)/ $(REMOTE_REP)/

clean:
	rm -fR $(BUILD_DIR) $(TMP_DIR)
