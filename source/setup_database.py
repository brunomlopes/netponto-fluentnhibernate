from common_database import config
from NHibernate.Tool import hbm2ddl
from System.IO import Path

hbm2ddl.SchemaExport(config).SetOutputFile(Path.GetFullPath("export.sql")).Execute(False, True, False)
