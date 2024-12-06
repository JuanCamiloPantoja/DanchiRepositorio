Create Database DanchiBaseDeDatos;
use DanchiBaseDeDatos;
create table Residente(
IdResidente int primary key,
NumApartamento nvarchar(4),
CorreoElectronico nvarchar(100),
CelularResidente numeric(10,0),
Nombre nvarchar(100)
);
create table Administrador(
IdAdministrador int primary key,
Nombre nvarchar (100),
CelularAdministrador numeric(10,0),
CorreoElctronicoAd nvarchar(100)
);
Create table AutenticacionUsuario(
TipoUsuario nvarchar(50),
Usuario nvarchar(50),
Contrase�a nvarchar(50));

create table ChatInterno(
IdChat int primary key,
IdAdministrador int constraint FK_Chat_Administrador foreign key references Administrador(IdAdministrador),
IdResidente int constraint FK_Chat_Residente foreign key references Residente(IdResidente),
Mensaje nvarchar (500),
Fecha date,
Hora Time,
EstadoDelMensaje nvarchar(50),
Asunto nvarchar(100),
Adjuntos varchar(MAX));

Create table SugerenciasReporteErrores(
IdSugerenciaError int primary key,
IdResidente int constraint FK_SugerenciaError_Residente foreign key references Residente(IdResidente),
Tipo_De_Reporte nvarchar (50),
Descripcion nvarchar(200),
Lugar nvarchar(100),
FechaYHora datetime
);

Create table InversionFondos(
IdInversion int primary key,
PlazoInversi�n nvarchar(100),
PrioridadImportancia nvarchar(100),
EstadoInversion nvarchar(50),
ObjetivosInversion nvarchar(100)
);

Create Table NotificacionEmergencia(
IdEmergencia int primary key,
Descripcion nvarchar(200),
AccionesRecomendadas nvarchar(200),
EstadoEmergencia nvarchar(50),
TipoEmergencia nvarchar(100),
Lugar nvarchar (100),
FechaYHora datetime
);

Create Table AnuncioAcontecimientos(
IdAcontecimiento int primary key,
TipoAcontecimiento nvarchar(100),
Descripcion nvarchar(100),
EstadoAcontecimiento nvarchar(100),
LugarAcontecimiento nvarchar(100),
FechayHora Datetime);

Create Table SoporteTecnico(
IdSoporte int primary key,
IdResidente int constraint FK_AyudaSoporte_Residente foreign key references Residente(IdResidente),
IdAministrador int constraint FK_AyudaSoporte_Administrador foreign key references Administrador(IdAdministrador),
ActividadAfectada nvarchar(100),
Descripcion nvarchar(100),
Prioridad nvarchar(50)
);

INSERT INTO Residente (IdResidente, NumApartamento, CorreoElectronico, CelularResidente, Nombre)
VALUES
    (1, '101B', 'juan.perez@example.com', 3001234567, 'Juan Perez'),
    (2, '102C', 'maria.lopez@example.com', 3007654321, 'Maria Lopez'),
    (3, '103D', 'carlos.gomez@example.com', 3209876543, 'Carlos Gomez');

INSERT INTO Administrador (IdAdministrador, Nombre, CelularAdministrador, CorreoElctronicoAd)
VALUES
    (1, 'Pedro Martinez', 3102345678, 'pedro.martinez@admin.com'),
    (2, 'Ana Rodriguez', 3118765432, 'ana.rodriguez@admin.com');

INSERT INTO AutenticacionUsuario (TipoUsuario, Usuario, Contrase�a)
VALUES
    ('Residente', 'juanp', 'password123'),
    ('Administrador', 'pedrom', 'adminpass'),
    ('Residente', 'marial', 'mypass2024');

INSERT INTO ChatInterno (IdChat, IdAdministrador, IdResidente, Mensaje, Fecha, Hora, EstadoDelMensaje, Asunto, Adjuntos)
VALUES
    (1, 1, 1, 'Hola Juan, �c�mo puedo ayudarte hoy?', '2024-08-01', '10:30:00', 'Enviado', 'Asistencia general', NULL),
    (2, 2, 2, 'Hola Mar�a, �tienes alg�n problema con el servicio?', '2024-08-01', '11:00:00', 'Enviado', 'Consulta sobre servicios', NULL),
    (3, 1, 3, 'Carlos, estamos revisando tu solicitud de soporte t�cnico.', '2024-08-02', '14:45:00', 'Enviado', 'Soporte t�cnico', NULL);

INSERT INTO SugerenciasReporteErrores (IdSugerenciaError, IdResidente, Tipo_De_Reporte, Descripcion, Lugar, FechaYHora)
VALUES
    (1, 1, 'Sugerencia', 'Me gustar�a sugerir una nueva funci�n.', 'Plataforma web', '2024-08-03 12:30:00'),
    (2, 2, 'Error', 'Hay un problema al cargar la p�gina.', 'Plataforma web', '2024-08-04 09:15:00'),
    (3, 3, 'Sugerencia', 'Ser�a �til tener una aplicaci�n m�vil.', 'Plataforma m�vil', '2024-08-05 16:20:00');

INSERT INTO InversionFondos (IdInversion, PlazoInversi�n, PrioridadImportancia, EstadoInversion, ObjetivosInversion)
VALUES
    (1, '6 meses', 'Alta', 'En progreso', 'Aumentar la capacidad del sistema'),
    (2, '1 a�o', 'Media', 'Planificado', 'Mejorar la seguridad de datos'),
    (3, '3 meses', 'Baja', 'Completado', 'Actualizar hardware obsoleto');

INSERT INTO NotificacionEmergencia (IdEmergencia, Descripcion, AccionesRecomendadas, EstadoEmergencia, TipoEmergencia, Lugar, FechaYHora)
VALUES
    (1, 'Corte de energ�a en el edificio', 'Usar generadores de respaldo', 'Activo', 'Corte de energ�a', 'Edificio A', '2024-08-06 08:45:00'),
    (2, 'Incendio en el piso 3', 'Evacuar inmediatamente', 'Resuelto', 'Incendio', 'Piso 3', '2024-08-07 14:30:00'),
    (3, 'Fuga de gas en la cocina', 'Cerrar la llave de gas principal', 'Activo', 'Fuga de gas', 'Cocina', '2024-08-08 10:15:00');

INSERT INTO AnuncioAcontecimientos (IdAcontecimiento, TipoAcontecimiento, Descripcion, EstadoAcontecimiento, LugarAcontecimiento, FechayHora)
VALUES
    (1, 'Fiesta', 'Fiesta de bienvenida para nuevos residentes', 'Programado', 'Sal�n de eventos', '2024-08-09 19:00:00'),
    (2, 'Reuni�n', 'Reuni�n anual de propietarios', 'Programado', 'Sala de conferencias', '2024-08-10 17:00:00'),
    (3, 'Mantenimiento', 'Mantenimiento del ascensor', 'Completado', 'Edificio B', '2024-08-11 09:00:00');

INSERT INTO SoporteTecnico (IdSoporte, IdResidente, IdAministrador, ActividadAfectada, Descripcion, Prioridad)
VALUES
    (1, 1, 1, 'Aplicaci�n m�vil', 'La aplicaci�n m�vil se cierra inesperadamente al intentar iniciar sesi�n.', 'Alta'),   
    (2, 2, 2, 'Plataforma web', 'Error en la base de datos al guardar cambios en el perfil de usuario.', 'Alta'),   
    (3, 3, 1, 'Servicio en l�nea', 'Interrupci�n de servicio intermitente que afecta la conexi�n con la plataforma en l�nea.', 'Alta'),
    (4, 1, 2, 'Sistema de autenticaci�n', 'Error al autenticar al usuario debido a un fallo en el sistema de autenticaci�n.',�'Media');