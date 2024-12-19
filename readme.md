# Trainee Course Results Management in ASP.NET MVC

This repository demonstrates a simple **Trainee Course Results Management System** built using **ASP.NET MVC**. It highlights key concepts like model validation, custom remote attributes, and Bootstrap for responsive UI design.

---

## Key Features

### 1. **Dynamic Results Display**
   - Shows trainee course results with key details:
     - **Name**
     - **Course Name**
     - **Trainee Degree**
     - **Result State** (Pass/Fail)
   - Results are styled dynamically:
     - **Green** for Pass
     - **Red** for Fail

### 2. **Model Validation**
   - Custom validation logic using `Remote` attributes.
   - Ensures:
     - **MinDegree** is less than **Degree**.
     - **Degree** is within a valid range (50-100).

### 3. **Responsive UI with Bootstrap**
   - Clean and modern UI built using **Bootstrap 5**.
   - Results are displayed in a well-structured, responsive list format.

---

## Purpose

The primary purpose of this project is educational, focusing on:
- **ASP.NET MVC Fundamentals**: Controllers, Models, Views, and Routing.
- **Model Validation**: Using `DataAnnotations` and custom validation attributes.
- **UI Design**: Integrating **Bootstrap** to create clean and responsive layouts.
- **Dynamic Data Display**: Show results dynamically in Razor views.
