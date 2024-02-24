function defaultCardV2(data) {
    let card = `
<div class="card-body">
    <h5 class="card-title">${data.Name}</h5>
    <p class="card-text">${data.Description}</p>
    <div class="border-0 price position-absolute bottom-0 end-0 justify-content-center align-items-center" style="width: 250px; height: 50px; border: 1px solid #ccc;">
        <span class="align-text-center h5">${data.Price} <small>${data.Weight ? "all'etto" : "a porzione"}</small></span>
    </div>
</div>
<div>
    <div class="btn-group">
        <button type="button" class="btn btn-outline-primary" style="border-color:black" onclick="transformUpdateV2('${data.Id}')">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="black" class="bi bi-pen-fill" viewBox="0 0 16 16">
                <path d="m13.498.795.149-.149a1.207 1.207 0 1 1 1.707 1.708l-.149.148a1.5 1.5 0 0 1-.059 2.059L4.854 14.854a.5.5 0 0 1-.233.131l-4 1a.5.5 0 0 1-.606-.606l1-4a.5.5 0 0 1 .131-.232l9.642-9.642a.5.5 0 0 0-.642.056L6.854 4.854a.5.5 0 1 1-.708-.708L9.44.854A1.5 1.5 0 0 1 11.5.796a1.5 1.5 0 0 1 1.998-.001"></path>
            </svg>
            <span class="visually-hidden">Update</span>
        </button>
        <button type="button" class="btn btn-outline-primary" style="border-color:black" onclick="deleteDish('${data.Id}')">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="black" class="bi bi-x-square" viewBox="0 0 16 16">
                <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2z"/>
                <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
            </svg>
            <span class="visually-hidden">Delete</span>
        </button>
    </div>
</div>`;
    return card;
}


function insertButton(idSection) {
    return `
    <div class="mx-2" id="insert-new-dish-button-${idSection}">
        <button type="button" class="btn btn-outline-primary" style="border-color:black; color: black;" onclick="insertNewDish(idSection)">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="black" class="bi bi-pencil" viewBox="0 0 16 16">
                <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 3.5 10.207V13h2.793L13.5 5.793 11.207 2.5zm1.586-.707L14.5 3.5l-2 2L10.793 3.793l2-2z" />
            </svg>
            Inserisci nuovo piatto
        </button>
    </div>
`;

}

function deleteDishButton(id) {
    return `
    <button type="button" class="btn btn-outline-primary" style="border-color:black" onclick="deleteDish('${id}')">
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="black" class="bi bi-x-square" viewBox="0 0 16 16">
            <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2z"/>
            <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
        </svg>
        <span class="visually-hidden">Button</span>
    </button>
`;

}

function insertNewDish(id) {
    let newCard = document.createElement("div");
    newCard.innerHTML = `
    <div class="card border-dark" style="background-color:#faf0b3;" id="create-new-dish-card-${id}">
        <div class="card-header bg-transparent border-dark">
            <h1 class="card-title">Aggiungi piatto</h1>
        </div>
        <div class="card-body">
            <form method="post" id="form-create-new-dish">
                <input id="sectionId" name="sectionId" type="hidden" value="${id}">
                <div class="mb-3 row">
                    <label for="dishName" class="col-sm-3 col-form-label">Nome piatto:</label>
                    <div class="col-sm-9">
                        <input type="text" id="dishName" name="dishName" class="form-control">
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="description" class="col-sm-3 col-form-label">Descrizione:</label>
                    <div class="col-sm-9">
                        <input type="text" id="description" name="description" class="form-control">
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="price" class="col-sm-3 col-form-label">Prezzo:</label>
                    <div class="col-sm-9">
                        <input type="text" id="price" name="price" class="form-control">
                    </div>
                </div>
                <div class="mb-3 row">
                    <div class="col-sm-9 offset-sm-3">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" id="newDish" name="newDish">
                            <label class="form-check-label" for="newDish">Novità</label>
                        </div>
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" id="weightDish" name="weightDish">
                            <label class="form-check-label" for="weightDish">A Porzione</label>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-end">
                    <div class="col-sm-9">
                        <button type="submit" class="btn btn-dark">Invia</button>
                    </div>
                </div>
            </form>
        </div>
        <div class="card-footer bg-transparent border-dark">
            <div class="d-flex justify-content-end">
                <button type="button" class="btn btn-link me-2" onclick="goBackFromInsert('${id}')">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-arrow-left" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M10.78 11.97a.75.75 0 0 0 0-1.06l-4.25-4.25a.75.75 0 1 0-1.06 1.06L8.69 11H2.75a.75.75 0 1 0 0 1.5h5.94l-3.97 3.97a.75.75 0 0 0 1.06 1.06l4.25-4.25a.75.75 0 0 0 0-1.06z"/>
                    </svg>
                </button>
            </div>
        </div>
    </div>
`;


    let nameContainer = "dishes-row-" + id;
    let cardContainer = document.getElementById(nameContainer);
    cardContainer.prepend(newCard);
    let nameInserButton = "insert-new-dish-button-" + id;
    let insertButtonVar = document.getElementById(nameInserButton).remove();
    document.getElementById('form-create-new-dish').addEventListener('submit', function (event) {
        event.preventDefault();

        let formData = {
            sectionId: document.querySelector('input[name="sectionId"]').value,
            dishName: document.querySelector('input[name="dishName"]').value,
            description: document.querySelector('input[name="description"]').value,
            price: document.querySelector('input[name="price"]').value,
            weight: document.querySelector('input[name="weightDish"]').checked,
            isNew: document.querySelector('input[name="newDish"]').checked
        };

        fetch('/Dish/Create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                window.location.href = '/Index';
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });


}

function goBackFromInsert(idSection) {
    let nameCreateCard = "create-new-dish-card-" + idSection;
    let card = document.getElementById(nameCreateCard).remove();
    let nameButtonContainer = "main-button-container-" + idSection;
    let mainButtonContainer = document.getElementById(nameButtonContainer)
    let insertButtonDiv = document.createElement("div");
    insertButtonDiv.innerHTML = insertButton(idSection);
    mainButtonContainer.prepend(insertButtonDiv);
}

function transformUpdate(obj) {
    let card = document.getElementById(obj.Id);
    let newCard = `
<div class="card border-dark" style="background-color:#faf0b3;">
    <div class="card-header bg-transparent border-dark">
        <h1 class="card-title">Modifica piatto</h1>
    </div>
    <div class="card-body">
        <form id="dishCardUpdateForm">
            <div class="mb-3 row">
                <input id="id" name="id" type="hidden" value="${obj.Id}">
                <label for="dishName" class="col-sm-3 col-form-label">Nome piatto:</label>
                <div class="col-sm-9">
                    <input type="text" id="dishName" name="dishName" class="form-control" value="${obj.Name}">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="description" class="col-sm-3 col-form-label">Descrizione:</label>
                <div class="col-sm-9">
                    <input type="text" id="description" name="description" class="form-control" value="${obj.Description}">
                </div>
            </div>
            <div class="mb-3 row">
                <label for="price" class="col-sm-3 col-form-label">Prezzo:</label>
                <div class="col-sm-9">
                    <input type="text" id="price" name="price" class="form-control" value="${obj.Price}">
                </div>
            </div>
            <div class="mb-3 row">
                <div class="col-sm-9 offset-sm-3">
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="newDish" name="newDish" ${obj.IsNew ? 'checked' : '' }>
                        <label class="form-check-label" for="newDish">Novità</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="checkbox" id="weightDish" name="weightDish" ${obj.weight ? 'checked' : '' }>
                        <label class="form-check-label" for="weightDish">A porzione</label>
                    </div>
                </div>
            </div>
            <div class="row justify-content-end">
                <div class="col-sm-9">
                    <button type="submit" class="btn btn-dark">Invia</button>
                </div>
            </div>
        </form>
    </div>
    <div class="card-footer bg-transparent border-dark">
        <div class="d-flex justify-content-end">
            <button type="button" class="btn btn-link me-2" onclick="goBack('${obj.Id}')">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-arrow-left" viewBox="0 0 16 16">
                    <path fill-rule="evenodd" d="M10.78 11.97a.75.75 0 0 0 0-1.06l-4.25-4.25a.75.75 0 1 0-1.06 1.06L8.69 11H2.75a.75.75 0 1 0 0 1.5h5.94l-3.97 3.97a.75.75 0 0 0 1.06 1.06l4.25-4.25a.75.75 0 0 0 0-1.06z"/>
                </svg>
            </button>
            ${deleteDishButton(obj.Id)}
        </div>
    </div>
</div>
`;

    let novitaButton = document.getElementById("novita-button");
    if (novitaButton != null) {
        novitaButton.remove();
    }
    card.innerHTML = newCard;
    document.getElementById('dishCardUpdateForm').addEventListener('submit', function (event) {
        event.preventDefault();

        let formData = {
            id: document.querySelector('input[name="id"]').value,
            dishName: document.querySelector('input[name="dishName"]').value,
            description: document.querySelector('input[name="description"]').value,
            price: document.querySelector('input[name="price"]').value,
            weight: document.querySelector('input[name="weightDish"]').checked,
            isNew: document.querySelector('input[name="newDish"]').checked
        };

        fetch('/Dish/Update', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                window.location.href = '/Index';
            })
            .catch(error => {
                console.error('Error:', error);
            });
    });
}




function transformUpdateV2(id) {
    fetch(`/Dish/ById?id=${id}`)
        .then(response => response.json())
        .then(data => {
            transformUpdate(data);
        })
        .catch(error => {
            console.error('Si è verificato un errore durante la richiesta:', error);
        });
}

function goBack(idValue) {
    fetch(`/Dish/ById?id=${idValue}`)
        .then(response => response.json())
        .then(data => {
            let oldCard = document.getElementById(data.Id);
            oldCard.innerHTML = defaultCardV2(data);
        })
        .catch(error => {
            console.error('Si è verificato un errore durante la richiesta:', error);
        });
}

function deleteDish(idValue) {
    if (confirm("Sei sicuro di voler eliminare questo piatto?")) {
        fetch(`/Dish/Delete?id=${idValue}`, {
            method: 'DELETE', // Assumendo che l'endpoint supporti il metodo DELETE
        })
            .then(data => {
                console.log("Piatto eliminato con successo", data);
                let cardToRemove = document.getElementById(data.Id);
                if (cardToRemove) cardToRemove.remove();
                window.location.href = '/Index';
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }
}