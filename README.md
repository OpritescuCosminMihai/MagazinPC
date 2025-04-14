# 🖥️ OverKhlocked – Magazin PC (Windows Forms)

**OverKhlocked** este o aplicație desktop creată cu C# și Windows Forms, dedicată gestionării unui magazin de componente și periferice PC.

---

## 🔧 Funcționalități principale

- 📄 Adăugare, editare și ștergere produse
- 📂 Salvare automată în fișiere text (Componenta / Periferic)
- 🔎 Căutare live după numele produsului
- 🧾 Validare date introduse (UI + logică)
- 🎨 Interfață modernizată cu hover pe carduri
- 🧭 Navigare intuitivă (Home / Products / etc.)

---

## 🧱 Structura codului

- `Produs.cs` – modelul de produs (nume, preț, stoc, categorie, furnizor, ID)
- `Furnizor.cs` – model furnizor cu validare contact
- `Magazin.cs` – listă centralizată de produse + metode
- `StocareDateComponente.cs` / `StocareDatePeriferice.cs` – încărcare/salvare fișiere
- `MainMenuForm.cs` – interfața principală
- `AddProductForm.cs` – formular adăugare/editează produs

---

## 🚀 Cum rulezi aplicația

1. Deschide soluția în Visual Studio
2. Asigură-te că fișierele `StocComponente.txt` și `StocPeriferice.txt` există în directorul bin/debug
3. Rulează proiectul – vei vedea meniul principal

---

## ✅ TODO / Planuri viitoare

- 🔀 Sortare produse după preț, stoc
- 🗂️ Filtrare după categorie
- 📊 Statistici (număr total, valoare stoc etc.)
- 🎨 Setări UI: culori personalizate

---

## 👨‍💻 Dezvoltat de

**Cosmin**
