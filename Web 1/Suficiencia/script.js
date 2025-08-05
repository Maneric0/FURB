const apiUrl = "https://jsonplaceholder.typicode.com/photos";
const localStorageKey = "photoData";

// Função para buscar e exibir a lista
async function fetchPhotos() {
    let photos = JSON.parse(localStorage.getItem(localStorageKey));

    if (!photos) {
        const response = await fetch(apiUrl);
        photos = await response.json();  // Carregar todas as 5000 imagens
        localStorage.setItem(localStorageKey, JSON.stringify(photos));
    }

    console.log("Imagens carregadas:", photos);  // Depuração

    renderPhotos(photos, 1);  // Inicia a exibição na primeira página
}

let currentPage = 1;
const itemsPerPage = 10;

// Renderiza apenas as imagens da página atual
function renderPhotos(photos, page) {
    currentPage = page;
    const list = document.getElementById("photo-list");
    list.innerHTML = "";

    // Define o intervalo das imagens a serem exibidas
    const start = (page - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    const paginatedPhotos = photos.slice(start, end);

    paginatedPhotos.forEach(photo => {
        list.innerHTML += `
            <tr>
                <td>${photo.id}</td>
                <td>${photo.title}</td>
                <td><img src="${photo.url}" alt="${photo.title}" onerror="this.onerror=null; this.src='fallback.jpg';"></td>
            </tr>
        `;
    });

    renderPagination(photos);
}

// Cria os botões de paginação
function renderPagination(photos) {
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = "";
    const totalPages = Math.ceil(photos.length / itemsPerPage);

    for (let i = 1; i <= totalPages; i++) {
        pagination.innerHTML += `<button class="btn btn-secondary mx-1" onclick="renderPhotos(${JSON.stringify(photos)}, ${i})">${i}</button>`;
    }
}


// Evento de inserir novo item
document.getElementById("insert-form").addEventListener("submit", function (event) {
    event.preventDefault();

    const title = document.getElementById("title").value;
    const url = document.getElementById("url").value;

    const photos = JSON.parse(localStorage.getItem(localStorageKey)) || [];
    const newPhoto = {
        id: photos.length > 0 ? photos[photos.length - 1].id + 1 : 1,
        title,
        url,
    };

    photos.push(newPhoto);
    localStorage.setItem(localStorageKey, JSON.stringify(photos));

    // Atualiza a lista
    renderPhotos(photos);
    this.reset();
});

// Evento para alterar um item
document.getElementById("update-form").addEventListener("submit", function (event) {
    event.preventDefault();

    const id = parseInt(document.getElementById("update-id").value);
    const title = document.getElementById("update-title").value;
    const url = document.getElementById("update-url").value;

    let photos = JSON.parse(localStorage.getItem(localStorageKey)) || [];

    // Busca o índice do item com o ID especificado
    const index = photos.findIndex(photo => photo.id === id);

    if (index !== -1) {
        // Atualiza os valores
        photos[index].title = title;
        photos[index].url = url;

        localStorage.setItem(localStorageKey, JSON.stringify(photos));
        renderPhotos(photos);
        this.reset();
    } else {
        alert("ID não encontrado.");
    }
});

// Evento de exclusão de item
document.getElementById("delete-form").addEventListener("submit", function (event) {
    event.preventDefault();

    const deleteId = parseInt(document.getElementById("delete-id").value);
    let photos = JSON.parse(localStorage.getItem(localStorageKey)) || [];

    // Filtra para remover o item com o ID especificado
    photos = photos.filter(photo => photo.id !== deleteId);

    localStorage.setItem(localStorageKey, JSON.stringify(photos));

    // Atualiza a lista
    renderPhotos(photos);
    this.reset();
});

// Inicializa a aplicação
fetchPhotos();