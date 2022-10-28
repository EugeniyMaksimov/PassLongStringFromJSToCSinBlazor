export function showPrompt(message): Uint8Array {
    alert(message);
    let str = "";
    for(let i = 0; i < 164232; i++)
        str += "A";
    return new TextEncoder().encode(str);
}