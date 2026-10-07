const form = document.getElementById("applyForm");
const messageBox = document.getElementById("message");
const submitButton = form.querySelector("button[type=submit]");

function getValue(id) {
    return document.getElementById(id).value.trim();
}

// Opsiyonel alan boşsa boş metin yerine null gönder
function getValueOrNull(id) {
    const value = getValue(id);
    return value === "" ? null : value;
}

// Formdaki değerleri API'nın beklediği JSON şekline çevirir
function buildApplication() {
    return {
        personInfo: {
            firstName: getValue("firstName"),
            lastName: getValue("lastName"),
            email: getValue("email"),
            phone: getValue("phone"),
            address: getValueOrNull("address"),
            imagePath: ""

        },
        university: getValue("university"),
        department: getValue("department"),
        classYear: Number(getValue("classYear")),
        linkedinURL: getValueOrNull("linkedinUrl"),
        githubURL: getValueOrNull("githubUrl"),
        notes:""
    };
}

function showMessage(type, messages) {
    messageBox.innerHTML = "";

    const alertDiv = document.createElement("div");
    alertDiv.className = `alert alert-${type}`;

    // textContent: sunucudan gelen metin HTML olarak yorumlanmasın
    messages.forEach(text => {
        const p = document.createElement("div");
        p.textContent = text;
        alertDiv.appendChild(p);
    });

    messageBox.appendChild(alertDiv);
}

form.addEventListener("submit", async (event) => {
    event.preventDefault();               // sayfa yenilenmesin
    messageBox.innerHTML = "";
    submitButton.disabled = true;         // çift tıklamayı engelle

    try {
        await submitApplication(buildApplication());
        showMessage("success", ["Başvurunuz alındı. Teşekkür ederiz!"]);
        form.reset();
    } catch (error) {
        const messages = error instanceof ApiError
            ? error.messages
            : ["Beklenmeyen bir hata oluştu."];
        showMessage("danger", messages);
    } finally {
        submitButton.disabled = false;
    }
});