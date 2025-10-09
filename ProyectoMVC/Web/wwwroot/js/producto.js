async function abrirFormulario(id = 0) {
    const res = await fetch(`/ProductoAjax/Form/${id}`);
    const html = await res.text();

    document.getElementById("contenidoModal").innerHTML = html;
    const modal = new bootstrap.Modal(document.getElementById("modalProducto"));
    modal.show();
}

async function guardarProducto() {
    const producto = {
        Id: parseInt(document.getElementById("Id").value || 0),
        Nombre: document.getElementById("Nombre").value,
        Descripcion: document.getElementById("Descripcion").value,
        Precio: parseFloat(document.getElementById("Precio").value),
        Stock: parseInt(document.getElementById("Stock").value)
    };

    if (!validar(producto))
    {
        return;
    }


    const res = await fetch("/ProductoAjax/Guardar", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(producto)
    });

    

    const data = await res.json();
    /*
    if (data.success) {
        alert("Guardado correctamente");
        location.reload();
    } else {
        alert("Error: " + data.message);
    }
    */

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

function validar(producto) {
    if (!producto.Nombre) {
        Swal.fire({
            icon: "warning",
            title: "Campo requerido",
            text: "Debe ingresar el nombre del producto"
        });
        return false;
    }

    if (!producto.Descripcion) {
        Swal.fire({
            icon: "warning",
            title: "Campo requerido",
            text: "Debe ingresar la descripción del producto"
        });
        return false;
    }

    if (isNaN(producto.Precio) || producto.Precio <= 0) {
        Swal.fire({
            icon: "warning",
            title: "Valor inválido",
            text: "El precio debe ser un número mayor que cero"
        });
        return false;
    }

    if (isNaN(producto.Stock) || producto.Stock < 0) {
        Swal.fire({
            icon: "warning",
            title: "Valor inválido",
            text: "El stock no puede ser negativo"
        });
        return false;
    }

    return true;
}


async function eliminarProducto(id) {
    if (!confirm("¿Seguro que deseas eliminar este producto?")) return;

    const res = await fetch(`/ProductoAjax/Eliminar/${id}`, {
        method: "POST"
    });

    const data = await res.json();

    if (data.success) {
        document.getElementById(`fila-${id}`).remove();
    } else {
        alert("Error: " + data.message);
    }
}
