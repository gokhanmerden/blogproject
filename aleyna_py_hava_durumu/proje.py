import sqlite3

# Veritabanına bağlanma komutu olarak yazdım.
baglanti = sqlite3.connect("hava_durumu.db", check_same_thread=False)

# İmleç oluşturma komutum.
imlec = baglanti.cursor()

# Veri okuma fonksiyonunu oluşturdum.
def veri_oku(sehir):
    imlec.execute("SELECT * FROM hava_durumu WHERE sehir = ?", (sehir,))
    sonuc = imlec.fetchall()
    return sonuc

# Veri yazma fonksiyonum.
def veri_yaz(sehir, tarih, sicaklik, nem, yagis, ruzgar,durum):
    imlec.execute("INSERT INTO hava_durumu VALUES (?, ?, ?, ?, ? ,?)", (sehir, tarih, sicaklik, nem, yagis, ruzgar,))
    baglanti.commit()

# Veri güncelleme fonkiyonum.
def veri_guncelle(sehir, tarih, sicaklik, nem, yagis, ruzgar,durum):
    imlec.execute("UPDATE hava_durumu SET sicaklik = ?, nem = ?, yagis = ?, ruzgar = ? WHERE sehir = ? AND tarih = ?", (sicaklik, nem, yagis, ruzgar, sehir, tarih))
    baglanti.commit()

# Veri silme fonksiyonumu oluşturdum.
def veri_sil(sehir, tarih):
    imlec.execute("DELETE FROM hava_durumu WHERE sehir = ? AND tarih = ?", (sehir, tarih))
    baglanti.commit()

# Servis katmanında fonksiyonlar tanımlıyorum.

# Hava durumu raporu oluşturma fonksiyonum:

def hava_raporu(sehir, tarih):
    veriler = veri_oku(sehir)
    for veri in veriler:
        if veri[1] == tarih:
            rapor = f"{sehir} şehrinin {tarih} tarihli hava durumu raporu:\n"
            rapor += f"Sıcaklık: {veri[2]} °C\n"
            rapor += f"Nem: {veri[3]} %\n"
            rapor += f"Yağış: {veri[4]} mm\n"
            rapor += f"Rüzgar: {veri[5]} km/s\n"
            return rapor
    return f"{sehir} şehrinin {tarih} tarihli hava durumu verisi bulunamadı."

# Hava durumu verisi ekleme fonksiyonum:

def veri_ekle(sehir, tarih, sicaklik, nem, yagis, ruzgar):
    veri_yaz(sehir, tarih, sicaklik, nem, yagis, ruzgar)
    return f"{sehir} şehrinin {tarih} tarihli hava durumu verisi başarıyla eklendi."

# Hava durumu verisi güncelleme fonksiyonunu oluşturdum:
def veri_guncelle(sehir, tarih, sicaklik, nem, yagis, ruzgar):
    veri_guncelle(sehir, tarih, sicaklik, nem, yagis, ruzgar)
    return f"{sehir} şehrinin {tarih} tarihli hava durumu verisi başarıyla güncellendi."

# Hava durumu verisi silme fonksiyonum:
def veri_sil(sehir, tarih):
    veri_sil(sehir, tarih)
    return f"{sehir} şehrinin {tarih} tarihli hava durumu verisi başarıyla silindi."

# Flask modülünü içe aktardım.
from flask import Flask, request, jsonify


# Flask uygulaması oluşturdum ve kaydettim.
app = Flask(__name__)

# Hava raporu servisi tanımladım.
@app.route("/hava_raporu", methods=["GET"])
def hava_raporu_servis():
    # Parametreleri almak için yazdım
    sehir = request.args.get("sehir")
    tarih = request.args.get("tarih")
    # Hava raporu oluşturdum.
    rapor = hava_raporu(sehir, tarih)
    # Raporu JSON formatında döndürmek için yazdım.
    return jsonify({"rapor": rapor})

# Veri ekleme servisini tanımladım.
@app.route("/veri_ekle", methods=["POST"])
def veri_ekle_servis():
    # Parametreleri alıyorum.
    sehir = request.form.get("sehir")
    tarih = request.form.get("tarih")
    sicaklik = request.form.get("sicaklik")
    nem = request.form.get("nem")
    yagis = request.form.get("yagis")
    ruzgar = request.form.get("ruzgar")

    # Veri ekleme fonksiyonumu çağırdım işleme aldım.
    mesaj = veri_ekle(sehir, tarih, sicaklik, nem, yagis, ruzgar)
    # Mesajı JSON formatında döndürdüm.
    return jsonify({"mesaj": mesaj})

# Veri güncelleme servisi tanımladım.
@app.route("/veri_guncelle", methods=["PUT"])
def veri_guncelle_servis():
    # Parametreleri aldım.
    sehir = request.form.get("sehir")
    tarih = request.form.get("tarih")
    sicaklik = request.form.get("sicaklik")
    nem = request.form.get("nem")
    yagis = request.form.get("yagis")
    ruzgar = request.form.get("ruzgar")
    # Veri güncelleme fonksiyonunu çağırmak için yazdım.
    mesaj = veri_guncelle(sehir, tarih, sicaklik, nem, yagis, ruzgar)
    # Mesajı JSON formatında döndürmek için yazdım.
    return jsonify({"mesaj": mesaj})

# Veri silme servisi tanımladım.
@app.route("/veri_sil", methods=["DELETE"])
def veri_sil_servis():
    # Parametreleri almak için yazdım.
    sehir = request.form.get("sehir")
    tarih = request.form.get("tarih")
    # Veri silme fonksiyonunu çağırmak için kullandım.
    mesaj = veri_sil(sehir, tarih)
    # Mesajı JSON formatında döndürmek için yazdım.
    return jsonify({"mesaj": mesaj})

# Uygulamayı çalıştırma fonksiyonum.
if __name__ == "__main__":
    app.run()