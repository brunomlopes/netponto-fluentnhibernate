from common_database import c
from NHibernate.Tool import hbm2ddl
from System.IO import Path, Directory


def with_mappings(mapping):
    mappingDirectory = Path.GetFullPath("mappings")
    if not Directory.Exists(mappingDirectory):
        Directory.CreateDirectory(mappingDirectory)
    mapping.AutoMappings.ExportTo(mappingDirectory)
    mapping.FluentMappings.ExportTo(mappingDirectory)
c.FluentConfiguration.Mappings(with_mappings)
c.FluentConfiguration.BuildConfiguration()
