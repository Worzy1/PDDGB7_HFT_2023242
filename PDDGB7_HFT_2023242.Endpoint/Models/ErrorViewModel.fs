namespace PDDGB7_HFT_2023242.Endpoint.Models

open System

type ErrorViewModel =
    { RequestId: string }

    member this.ShowRequestId =
        not (String.IsNullOrEmpty(this.RequestId))
