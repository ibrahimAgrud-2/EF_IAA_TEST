const API_BASE = "https://localhost:7042/api";

async function loadProjects() {
    const response = await fetch(`${API_BASE}/projects/all`);

    if (!response.ok) {
        console.error("API hatası:", response.status);
        return;
    }

    const projects = await response.json();
    console.log(projects); // önce konsolda yapıyı gör

    const tbody = document.getElementById("projectsBody");
    tbody.innerHTML = "";

    projects.forEach(p => {
        tbody.innerHTML += `
            <tr>
                <td>${p.projectID}</td>
                <td>${p.title}</td>
                <td>${p.technologies}</td>
            </tr>`;
    });
}

loadProjects();