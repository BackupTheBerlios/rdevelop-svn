PACKAGE    = rdevelop-mime-info
VERSION    = 0.`svnversion | cut -d: -f1 | sed 's/[a-zA-Z]//'`
MAINTAINER = Sebastien Nicouleaud
EMAIL      = sebastien.nicouleaud@gmail.com
DATE       = `date -R`

BUILDDIR    = build
PKGFULLNAME = $(PACKAGE)-$(VERSION)
PKGBUILDDIR = $(BUILDDIR)/$(PKGFULLNAME)
ORIGTGZ     = $(BUILDDIR)/$(PACKAGE)_$(VERSION).orig.tar.gz
DEB         = $(BUILDDIR)/$(PACKAGE)-$(VERSION).deb

SED_SCRIPT = "s/<package>/$(PACKAGE)/g;\
s/<version>/$(VERSION)/g;\
s/<maintainer>/$(MAINTAINER)/g;\
s/<email>/$(EMAIL)/g;\
s/<date and time>/$(DATE)/g"

DEBFILES = `ls debian`

SOURCES = rdevelop.xml README.txt

all:
	install -d $(PKGBUILDDIR)/debian
	install $(SOURCES) $(PKGBUILDDIR)
	tar -C $(BUILDDIR) -czf $(ORIGTGZ) $(PKGFULLNAME)
	for debfile in $(DEBFILES); do sed -e $(SED_SCRIPT) debian/$${debfile} > $(PKGBUILDDIR)/debian/$${debfile}; done
	chmod +x $(PKGBUILDDIR)/debian/rules
	cd $(PKGBUILDDIR) && debuild -us -uc

clean:
	rm -fR $(BUILDDIR)

LOCALREP    = $(BUILDDIR)/repository
REMOTEREP   = shell.berlios.de:/home/groups/ftp/pub/rdevelop/debian
RSYNC       = rsync
RSYNC_FLAGS = -aze ssh

upload:
	install -d $(LOCALREP)
	$(RSYNC) $(RSYNC_FLAGS) $(REMOTEREP)/ $(LOCALREP)/
	cd $(LOCALREP) && dpkg-scanpackages . /dev/null | gzip -9c > Packages.gz
	cd $(LOCALREP) && dpkg-scansources . /dev/null | gzip -9c > Sources.gz
	cp -f $(BUILDDIR)/*.deb $(BUILDDIR)/*.gz $(BUILDDIR)/*.dsc $(LOCALREP)
	$(RSYNC) $(RSYNC_FLAGS) --delete --force $(LOCALREP)/ $(REMOTEREP)/

