-- Script para insertar tipos de contacto básicos
-- Ejecutar este script en tu base de datos ModuloCurriculumVite4

USE ModuloCurriculumVite4;
GO

-- Insertar tipos de contacto en la tabla CV.TipoContacto
IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 1)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (1, 'LinkedIn');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 2)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (2, 'Facebook');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 3)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (3, 'Twitter/X');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 4)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (4, 'Instagram');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 5)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (5, 'YouTube');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 6)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (6, 'GitHub');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 7)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (7, 'ResearchGate');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 8)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (8, 'ORCID');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 9)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (9, 'Academia.edu');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 10)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (10, 'Google Scholar');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 11)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (11, 'Página Web Personal');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 12)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (12, 'Blog Personal');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 13)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (13, 'WhatsApp Business');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 14)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (14, 'Skype');
END

IF NOT EXISTS (SELECT 1 FROM CV.TipoContacto WHERE tipoContactoId = 15)
BEGIN
    INSERT INTO CV.TipoContacto (tipoContactoId, nombre) VALUES (15, 'Telegram');
END

-- Verificar que se insertaron correctamente
SELECT 'TipoContacto' as Tabla, COUNT(*) as Total FROM CV.TipoContacto;

PRINT '🇲🇽 Tipos de contacto insertados correctamente para el sistema de gestión de contactos de docentes'; 