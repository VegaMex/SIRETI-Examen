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
    tipo_usuario TINYINT NOT NULL COMMENT '0 ADMIN 1 COORDINADOR 2 ENCARGADO 3 DOCENTE',
    FOREIGN KEY (carrera_usuario) REFERENCES carreras (id_carrera)
);

INSERT INTO carreras (nombre_carrera) VALUES ("Admin");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Sistemas Computacionales");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Informática");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Electrónica");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Sistemas Automotrices");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Ambiental");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Industrial");
INSERT INTO carreras (nombre_carrera) VALUES ("Ing. Gestión Empresarial");
INSERT INTO carreras (nombre_carrera) VALUES ("Lic. Gastronomía");

INSERT INTO usuarios (nombre_usuario, paterno_usuario, materno_usuario, correo_usuario, contra_usuario, carrera_usuario, tipo_usuario) VALUES ("admin", "admin", "admin", "a@a.aa", SHA1("Abc12#45"), 1, 0);