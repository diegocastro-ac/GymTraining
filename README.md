# GymTraining

Aplicación de consola para la gestión de entrenamientos: usuarios, rutinas y ejercicios (de fuerza y cardio).

## Stack

- .NET 10
- C#
- Arquitectura por capas: Domain / Application / Infrastructure / Console

## Estructura del proyecto

| Capa | Responsabilidad | Contenido |
|------|----------------|-----------|
| `Domain` | Modelo de negocio y reglas de dominio | Entidades (`Exercise`, `StrengthExercise`, `CardioExercise`, `Routine`, `User`) y enums (`MuscleGroup`, `TrainingGoal`) |
| `Application` | Casos de uso y estado de la aplicación | Servicios de orquestación (`UserService`, `RoutineService`, `ExerciseService`), interfaces de repositorio, y generadores de rutinas |
| `Infrastructure` | Persistencia | Implementación concreta de repositorios (`InMemoryUserRepository`) |
| `Console` | Interfaz de usuario | Menús de consola (`ConsoleApp`, `RoutineMenu`, `ExerciseMenu`) y punto de entrada (`Program.cs`) |

## Funcionalidades

- Crear usuarios y seleccionar el usuario activo.
- Crear rutinas de entrenamiento, asociadas a un objetivo (`TrainingGoal`).
- Generar automáticamente una rutina completa según el objetivo seleccionado (fuerza, hipertrofia, resistencia, fitness general, ganancia muscular o pérdida de peso), pre-cargada con ejercicios y volúmenes coherentes.
- Añadir ejercicios de fuerza o cardio a una rutina existente, con validación de sus datos (series, repeticiones, peso, duración, distancia).
- Generar un plan de nutrición según el objetivo (fuerza o pérdida de peso): macros diarias, plan de comidas y suplementos coherentes entre sí.
- Ver la rutina y ejecutar los ejercicios que la componen.

## Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/)

## Cómo ejecutar

```bash
dotnet run --project Console
```

## Cómo compilar

```bash
dotnet build GymTraining.slnx
```