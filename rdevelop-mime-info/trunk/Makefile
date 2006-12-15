PREFIX=/usr/local
MIME_DIR=$(PREFIX)/share/mime
MIME_PKG_DIR=$(MIME_DIR)/packages
MIME_FILE=rdevelop.xml

UPDATE_MIME_DATABASE=update-mime-database
RM=rm -f
INSTALL=install

all:
	@echo 'Run "make install".'

install:
	$(INSTALL) -d $(MIME_PKG_DIR)
	$(INSTALL) $(MIME_FILE) $(MIME_PKG_DIR)
	$(UPDATE_MIME_DATABASE) $(MIME_DIR)

uninstall:
	$(RM) $(MIME_FILE)

