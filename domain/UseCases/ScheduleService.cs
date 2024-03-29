namespace Domain;

public class ScheduleService
{
    public readonly IScheduleRepository _repository;

    public ScheduleService(IScheduleRepository repository)
    {
        _repository = repository;
    }

    async public Task<Result<Schedule>> GetSchedule(int doctorID, DateOnly date)
    {
        var schedule = await _repository.GetSchedule(doctorID, date);

        if (schedule is not null)
            return Result.Ok<Schedule>(schedule);

        return Result.Err<Schedule>("Schedule not found");
    }

    async public Task<Result<Schedule>> AddSchedule(ScheduleForm form)
    {
        var schedule = await _repository.AddSchedule(form);

        if (schedule is not null)
            return Result.Ok<Schedule>(schedule);

        return Result.Err<Schedule>("Failed to add schedule");
    }
    async public Task<Result<Schedule>> ChangeSchedule(ScheduleForm actual, ScheduleForm recent)
    {
        var schedule = await _repository.ChangeSchedule(actual, recent);

        if (schedule is not null)
            return Result.Ok<Schedule>(schedule);

        return Result.Err<Schedule>("Failed to change schedule");
    }
}