CREATE DATABASE sireti;
USE sireti;

CREATE TABLE carreras (
    id_carrera INT PRIMARY KEY AUTO_INCREMENT,
    nombre_carrera VARCHAR (50) NOT NULL
);

CREATE TABLE alumnos (
    id_alumno INT PRIMARY KEY AUTO_INCREMENT,
    control_alumno CHAR (9) NOT NULL UNIQUE,
    nombre_alumno VARCHAR (50) NOT NULL,
    paterno_alumno VARCHAR (50) NOT NULL,
    materno_alumno VARCHAR (50),
    correo_alumno VARCHAR (200) NOT NULL UNIQUE,
    contra_alumno VARCHAR (200) NOT NULL,
    carrera_alumno INT NOT NULL,
    tipo_alumno INT NOT NULL,
    FOREIGN KEY (carrera_alumno) REFERENCES carreras (id_carrera)
);

CREATE TABLE usuarios (
    id_usuario INT PRIMARY KEY AUTO_INCREMENT,
    nombre_usuario VARCHAR (50) NOT NULL,
    paterno_usuario VARCHAR (50) NOT NULL,
    materno_usuario VARCHAR (50),
    correo_usuario VARCHAR (50) NOT NULL UNIQUE,
    contra_usuario VARCHAR (200) NOT NULL,
    carrera_usuario INT NOT NULL,
    tipo_usuario INT NOT NULL COMMENT '0 ADMIN 1 ALUMNO 2 COORDINADOR 3 ENCARGADO 4 DOCENTE',
    FOREIGN KEY (carrera_usuario) REFERENCES carreras (id_carrera)
);

INSERT INTO carreras (nombre_carrera) VALUES ("Admin"); -- 1
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Sistemas Computacionales"); -- 2
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Informática"); -- 3
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Electrónica"); -- 4
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Sistemas Automotrices"); -- 5
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Ambiental"); -- 6
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Industrial"); -- 7
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Gestión Empresarial"); -- 8
INSERT INTO carreras (nombre_carrera) VALUES ("Lic. Gastronomía"); -- 9

INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario) VALUES ('admin', 'admin', 'admin', 'a@a.aa', SHA1('Abc12#45'), 1, 0);
INSERT INTO alumnos (control_alumno, nombre_alumno, paterno_alumno, materno_alumno, correo_alumno, contra_alumno, carrera_alumno, tipo_alumno) VALUES ('S16120245', 'Óscar', 'Vega', 'López', 'oscar@mail.com', SHA1('Abc12#45'), 2, 1);

INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario) 
	VALUES ('Miguel', 'Cruz', 'Pineda', 'sistemas@itsur.edu.mx', SHA1('Abc12#45'), 2, 2);
INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario) 
	VALUES ('Efrén', 'Vega', 'Chávez', 'e.vega@itsur.edu.mx', SHA1('Abc12#45'), 2, 3);
INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario) 
	VALUES ('Gabriel', 'Magaña', 'Guzmán', 'g.magana@itsur.edu.mx', SHA1('Abc12#45'), 7, 2);
INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario) 
	VALUES ('Gustavo Iván', 'Vega', 'Olvera', 'gi.vega@itsur.edu.mx', SHA1('Abc12#45'), 2, 4);