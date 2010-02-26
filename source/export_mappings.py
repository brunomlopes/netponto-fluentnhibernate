from common_database import c
from NHibernate.Tool import hbm2ddl
from System.IO import Path, Directory


def with_mappings(mapping):
    mappingDirectory = Path.GetFullPath(r"mappings")
    if not Directory.Exists(mappingDirectory):
        Directory.CreateDirectory(mappingDirectory)
    mapping.AutoMappings.ExportTo(mappingDirectory)

c.GetFluentConfiguration().Mappings(with_mappings)
c.GetFluentConfiguration().BuildConfiguration()
