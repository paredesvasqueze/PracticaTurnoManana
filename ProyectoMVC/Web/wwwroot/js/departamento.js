// Renombrado para reflejar el modelo
async function abrirFormulario(id = 0) {
    // Usamos el nuevo controlador y la función Form
    const res = await fetch(`/DepartamentoHospitalAjax/Form/${id}`);
    const html = await res.text();

    document.getElementById("contenidoModal").innerHTML = html;
    // Usamos el ID del modal de la vista
    const modal = new bootstrap.Modal(document.getElementById("modalDepartamento"));
    modal.show();
}

// Renombrado para reflejar el modelo
async function guardarDepartamento() {
    // Mapeamos las propiedades con los IDs de los campos HTML y los nombres del modelo C#
    const departamento = {
        nIdDepartamento: parseInt(document.getElementById("nIdDepartamento").value || 0),
        cNombre: document.getElementById("cNombre").value,
        cDescripcion: document.getElementById("cDescripcion").value,
        nCantidadPersonal: parseInt(document.getElementById("nCantidadPersonal").value),
        cUbicacion: document.getElementById("cUbicacion").value
    };

    // Usamos la nueva función de validación
    if (!validarDepartamento(departamento)) {
        return;
    }

    // Usamos el nuevo controlador y la acción Guardar
    const res = await fetch("/DepartamentoHospitalAjax/Guardar", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(departamento)
    });

    const data = await res.json();

    // (Lógica de SweetAlert para respuesta)
    if (data.success) {
        Swal.fire({
            icon: "success",
            title: "Guardado correctamente",
            showConfirmButton: false,
            timer: 2000
        }).then(() => {
            location.reload();
        });
    } else {
        Swal.fire({
            icon: "error",
            title: "Error",
            text: data.message
        });
    }
}

// Renombrado y ajustado para el modelo DepartamentoHospital
function validarDepartamento(departamento) {
    if (!departamento.cNombre) {
        Swal.fire({
            icon: "warning",
            title: "Campo requerido",
            text: "Debe ingresar el nombre del departamento"
        });
        return false;
    }

    if (!departamento.cDescripcion) {
        Swal.fire({
            icon: "warning",
            title: "Campo requerido",
            text: "Debe ingresar la descripción del departamento"
        });
        return false;
    }

    if (isNaN(departamento.nCantidadPersonal) || departamento.nCantidadPersonal < 0) {
        Swal.fire({
            icon: "warning",
            title: "Valor inválido",
            text: "La cantidad de personal no puede ser negativa"
        });
        return false;
    }

    if (!departamento.cUbicacion) {
        Swal.fire({
            icon: "warning",
            title: "Campo requerido",
            text: "Debe ingresar la ubicación del departamento"
        });
        return false;
    }

    return true;
}


// Renombrado para reflejar el modelo
async function eliminarDepartamento(id) {
    // Confirmación nativa o SweetAlert
    if (!confirm("¿Seguro que deseas eliminar este departamento?")) return;

    // Usamos el nuevo controlador y la acción Eliminar
    const res = await fetch(`/DepartamentoHospitalAjax/Eliminar/${id}`, {
        method: "POST"
    });

    const data = await res.json();

    if (data.success) {
        // Eliminamos la fila de la tabla sin recargar
        document.getElementById(`fila-${id}`).remove();
    } else {
        alert("Error: " + data.message);
    }
}