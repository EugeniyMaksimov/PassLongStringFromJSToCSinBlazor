export function showPrompt(message) {
    alert(message);
    let str = "";
    for (let i = 0; i < 164232; i++)
        str += "A";
    return new TextEncoder().encode(str);
}
//# sourceMappingURL=Script.js.map