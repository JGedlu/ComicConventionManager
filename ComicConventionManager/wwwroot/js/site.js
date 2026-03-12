document.querySelectorAll(".edit").forEach(btn => {

    btn.addEventListener("click", function () {

        let card = btn.closest(".notice-card");

        card.querySelector(".notice-title").style.display = "none";
        card.querySelector(".notice-content").style.display = "none";

        card.querySelector(".notice-admin-controls").style.display = "none";

        card.querySelector(".notice-edit-area").style.display = "block";

    });

});


document.querySelectorAll(".cancel-btn").forEach(btn => {

    btn.addEventListener("click", function () {

        location.reload();

    });

});

document.querySelectorAll(".save-btn").forEach(btn => {

    btn.addEventListener("click", async function () {

        let card = btn.closest(".notice-card");

        let id = card.dataset.id;
        let title = card.querySelector(".notice-edit-title").value;
        let content = card.querySelector(".notice-edit-content").value;

        await fetch("/Notice/Update", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                noticeId: id,
                title: title,
                content: content
            })
        });

        location.reload();

    });

});