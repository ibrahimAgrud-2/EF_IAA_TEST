const API_BASE = "https://localhost:7042/api";

// API'dan gelen her hata bu tipte döner; sayfa script'i sadece mesajları gösterir
class ApiError extends Error {
    constructor(status, messages) {
        super(messages.join(" "));
        this.status = status;
        this.messages = messages;
    }
}

async function readErrorMessages(response) {
    if (response.status >= 500) {
        return ["Sunucuda bir hata oluştu. Lütfen daha sonra tekrar deneyin."];
    }

    const text = await response.text();

    try {
        const data = JSON.parse(text);
        // ASP.NET model doğrulama hatası: { errors: { Alan: ["mesaj"] } }
        if (data && data.errors) return Object.values(data.errors).flat();
        if (data && data.title) return [data.title];
    } catch {
        // JSON değil, düz metin (BadRequest("...") durumu)
    }

    return [text || `İstek reddedildi (kod: ${response.status}).`];
}

async function apiPost(path, body) {
    let response;

    try {
        response = await fetch(`${API_BASE}/${path}`, {
            method: "POST",
            headers: { "Content-Type": "Application/json" },
            body: JSON.stringify(body)
        });
    } catch {
        throw new ApiError(0, ["Sunucuya ulaşılamadı. Lütfen tekrar deneyin."]);
    }

    if (!response.ok) {
        throw new ApiError(response.status, await readErrorMessages(response));
    }

    return response.status === 204 ? null : await response.json();
}

// ---- Başvuru işlemleri ----
function submitApplication(application) {
    return apiPost("Application", application);
}