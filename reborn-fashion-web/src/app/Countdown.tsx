"use client"
import { useEffect, useState } from "react";


export const Countdown = (props: { end: Date }) => {
    const [remainingSecs, setRemainingSecs] = useState(getRemainingSecs(props.end));

    useEffect(() => {
        setInterval(() => {
            const remainingSecs = getRemainingSecs(props.end);
            setRemainingSecs(remainingSecs);
        }, 1000);
    }, []);

    if (remainingSecs < 0) return <div>Closed</div>

    const show1HrCountdown = remainingSecs < 3600;

    return <div className="text-sm">
        {show1HrCountdown ?
            <span suppressHydrationWarning={true} className="text-orange-500">{getMinutes(remainingSecs)}m {getSeconds(remainingSecs)}s left </span> :
            <span suppressHydrationWarning={true}>{getHours(remainingSecs)}hrs left</span>
        }
    </div>
}

const getRemainingSecs = (end: Date) => Math.floor((end.getTime() - Date.now()) / 1000);

const getHours = (remainingSecs: number) => Math.floor(remainingSecs / 3600);

const getMinutes = (remainingSecs: number) => {
    remainingSecs %= 3600;
    return Math.floor(remainingSecs / 60);
}

const getSeconds = (remainingSecs: number) => remainingSecs % 60;