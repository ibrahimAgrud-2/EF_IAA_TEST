// Durum numarası -> ekranda gösterilecek metin ve rozet rengi (tek yerde tutulur)
const STATUS = {
    0: { text: "Yeni", badge: "bg-primary" },
    1: { text: "İptal", badge: "bg-secondary" },
    2: { text: "Reddedildi", badge: "bg-danger" },
    3: { text: "Onaylandı", badge: "bg-success" }
};
const STATUS_NEW = 0;

const statusBox = document.getElementById("statusBox");
const tableWrapper = document.getElementById("tableWrapper");
const tableBody = document.getElementById("applicationsBody");

// ---------- Mesaj kutusu ----------
function showStatus(type, messages) {
    statusBox.replaceChildren();
    statusBox.className = `alert alert-${type}`;

    messages.forEach(text => {
        const line = document.createElement("div");
        line.textContent = text;
        statusBox.appendChild(line);
    });

    statusBox.hidden = false;
}

function hideStatus() {
    statusBox.hidden = true;
}

// ---------- Hücre oluşturucular (veri her zaman textContent ile yazılır) ----------
function createCell(text) {
    const td = document.createElement("td");
    td.textContent = text ?? "";
    return td;
}

function formatDate(isoDate) {
    if (!isoDate) return "";
    return new Date(isoDate).toLocaleDateString("tr-TR");
}

function createLinkItem(label, url) {
    if (!url) return null;

    // Sadece http(s) adresleri tıklanabilir yapılır
    if (/^https?:\/\//i.test(url)) {
        const a = document.createElement("a");
        a.href = url;
        a.textContent = label;
        a.target = "_blank";
        a.rel = "noopener noreferrer";
        return a;
    }

    const span = document.createElement("span");
    span.textContent = `${label}: ${url}`;
    return span;
}

function createLinksCell(application) {
    const td = document.createElement("td");

    [
        createLinkItem("LinkedIn", application.linkedinURL),
        createLinkItem("GitHub", application.githubURL)
    ]
        .filter(Boolean)
        .forEach(item => {
            const line = document.createElement("div");
            line.appendChild(item);
            td.appendChild(line);
        });

    return td;
}

function createStatusCell(status) {
    const td = document.createElement("td");
    const info = STATUS[status] ?? { text: "Bilinmiyor", badge: "bg-warning text-dark" };

    const badge = document.createElement("span");
    badge.className = `badge ${info.badge}`;
    badge.textContent = info.text;

    td.appendChild(badge);
    return td;
}

function createActionButton(text, cssClass, action, applicationId) {
    const button = document.createElement("button");
    button.type = "button";
    button.className = `btn btn-sm ${cssClass} me-1`;
    button.textContent = text;
    // Butonları bağlayacağımız adımda bu iki bilgi işimizi görecek
    button.dataset.action = action;
    button.dataset.applicationId = applicationId;
    return button;
}

function createActionsCell(application) {
    const td = document.createElement("td");

    // Onay/ret butonları sadece "Yeni" başvurularda görünür
    if (application.status === STATUS_NEW) {
        td.appendChild(createActionButton("Onayla", "btn-success", "approve", application.applicationID));
        td.appendChild(createActionButton("Reddet", "btn-danger", "reject", application.applicationID));
    }

    return td;
}

// ---------- Satır ve tablo ----------
function createRow(application) {
    const person = application.personInfo ?? {};
    const tr = document.createElement("tr");

    tr.appendChild(createCell(`${person.firstName ?? ""} ${person.lastName ?? ""}`.trim()));
    tr.appendChild(createCell(person.email));
    tr.appendChild(createCell(application.university));
    tr.appendChild(createCell(application.department));
    tr.appendChild(createCell(application.classYear));
    tr.appendChild(createCell(formatDate(application.applicationDate)));
    tr.appendChild(createLinksCell(application));
    tr.appendChild(createStatusCell(application.status));
    tr.appendChild(createActionsCell(application));

    return tr;
}

function renderApplications(applications) {
    tableBody.replaceChildren();
    applications.forEach(application => tableBody.appendChild(createRow(application)));
}

// ---------- Sayfa akışı ----------
async function loadApplications() {
    tableWrapper.hidden = true;
    showStatus("info", ["Başvurular yükleniyor..."]);

    try {
        const applications = await getAllApplications();

        if (applications.length === 0) {
            showStatus("secondary", ["Henüz başvuru yok."]);
            return;
        }

        // En yeni başvuru en üstte
        const sorted = [...applications].sort(
            (a, b) => new Date(b.applicationDate) - new Date(a.applicationDate)
        );

        renderApplications(sorted);
        hideStatus();
        tableWrapper.hidden = false;
    } catch (error) {
        const messages = error instanceof ApiError
            ? error.messages
            : ["Beklenmeyen bir hata oluştu."];
        showStatus("danger", messages);
    }
}

loadApplications();