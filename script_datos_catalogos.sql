-- Script para crear datos básicos en catálogos faltantes
-- Ejecutar estos INSERTs en tu base de datos ModuloCurriculumVite4

USE ModuloCurriculumVite4;
GO

-- 1. CATEGORÍAS (si no existen)
IF NOT EXISTS (SELECT 1 FROM UTL.Categorias WHERE IdCategoria = 1)
BEGIN
    INSERT INTO UTL.Categorias (IdCategoria, ClaveCategoria, NombreCategoria) 
    VALUES (1, 'TC', 'Tiempo Completo');
END

IF NOT EXISTS (SELECT 1 FROM UTL.Categorias WHERE IdCategoria = 2)
BEGIN
    INSERT INTO UTL.Categorias (IdCategoria, ClaveCategoria, NombreCategoria) 
    VALUES (2, 'MT', 'Medio Tiempo');
END

IF NOT EXISTS (SELECT 1 FROM UTL.Categorias WHERE IdCategoria = 3)
BEGIN
    INSERT INTO UTL.Categorias (IdCategoria, ClaveCategoria, NombreCategoria) 
    VALUES (3, 'ASG', 'Asignatura');
END

-- 2. NOMBRAMIENTOS (si no existen)
IF NOT EXISTS (SELECT 1 FROM UTL.Nombramiento WHERE IdNombramiento = 1)
BEGIN
    INSERT INTO UTL.Nombramiento (IdNombramiento, Nombramiento) 
    VALUES (1, 'Base');
END

IF NOT EXISTS (SELECT 1 FROM UTL.Nombramiento WHERE IdNombramiento = 2)
BEGIN
    INSERT INTO UTL.Nombramiento (IdNombramiento, Nombramiento) 
    VALUES (2, 'Interino');
END

IF NOT EXISTS (SELECT 1 FROM UTL.Nombramiento WHERE IdNombramiento = 3)
BEGIN
    INSERT INTO UTL.Nombramiento (IdNombramiento, Nombramiento) 
    VALUES (3, 'Honorarios');
END

-- 3. PRODEP (si no existen)
IF NOT EXISTS (SELECT 1 FROM UTL.PRODEP WHERE IdPRODEP = 1)
BEGIN
    INSERT INTO UTL.PRODEP (IdPRODEP, TienePRODEP) 
    VALUES (1, 'Sí');
END

IF NOT EXISTS (SELECT 1 FROM UTL.PRODEP WHERE IdPRODEP = 2)
BEGIN
    INSERT INTO UTL.PRODEP (IdPRODEP, TienePRODEP) 
    VALUES (2, 'No');
END

-- Verificar que todos los datos están insertados
SELECT 'Categorías' as Tabla, COUNT(*) as Total FROM UTL.Categorias
UNION ALL
SELECT 'Nombramientos' as Tabla, COUNT(*) as Total FROM UTL.Nombramiento  
UNION ALL
SELECT 'PRODEP' as Tabla, COUNT(*) as Total FROM UTL.PRODEP
UNION ALL
SELECT 'Sexo' as Tabla, COUNT(*) as Total FROM UTL.Sexo
UNION ALL
SELECT 'EstadoCivil' as Tabla, COUNT(*) as Total FROM UTL.EstadoCivil
UNION ALL
SELECT 'Escolaridad' as Tabla, COUNT(*) as Total FROM UTL.Escolaridad
UNION ALL
SELECT 'SNI' as Tabla, COUNT(*) as Total FROM UTL.SNI
UNION ALL
SELECT 'Carreras' as Tabla, COUNT(*) as Total FROM CEF.Carreras;

PRINT '🇲🇽 Datos básicos insertados correctamente para el CRUD de Docentes'; 